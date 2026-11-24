using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public class UserService : IUserService
    {   
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly LocalDbContext _dbContext;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, LocalDbContext dbContext)
        {     
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task<UserResponse> CreateAsync(UserRequest userRequest)
        {  
            User user = MapToEntity(userRequest);

            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            ThrowIfIdentityFailed(await _userManager.CreateAsync(user, userRequest.Password));           
            await SetOrChangeUserRoleAsync(user, userRequest.Role);
            await transaction.CommitAsync();

            return await MapToResponseAsync(user);
        }

        public async Task<UserResponse?> FindByIdAsync(int id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());            
            return user == null ? null : await MapToResponseAsync(user);

        }

        public async Task<UserResponse?> UpdateAsync(int id, UserRequest userRequest)
        {                  
            User? existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
                return null;
            MapToEntity(userRequest, existingUser);

            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            ThrowIfIdentityFailed(await _userManager.UpdateAsync(existingUser));            
            await SetOrChangeUserRoleAsync(existingUser, userRequest.Role);
            if(!string.IsNullOrWhiteSpace(userRequest.Password))
            {                
                ThrowIfIdentityFailed(await _userManager.RemovePasswordAsync(existingUser));
                ThrowIfIdentityFailed(await _userManager.AddPasswordAsync(existingUser, userRequest.Password));                
            }
            await transaction.CommitAsync();
            
            return await MapToResponseAsync(existingUser);

        }

        public async Task<bool> DeleteAsync(int id)
        {            
            User? existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
                return false;

            IdentityResult result =  await _userManager.DeleteAsync(existingUser);            
            return result.Succeeded;

        }

        private static User MapToEntity(UserRequest userRequest, User? user = null)
        {
            if (user == null)
                user = new User();

            user.UserName = userRequest.UserName;            
            user.FullName = userRequest.FullName;            

            return user;                

        }

        private async Task<UserResponse> MapToResponseAsync(User user)
        {
            string role = await GetUserRoleAsync(user);
            return new UserResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Role = role

            };
            
        }

        private async Task<string> GetUserRoleAsync(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault() ?? string.Empty;
        }       

        private async Task SetOrChangeUserRoleAsync(User user, string role)
        {   
            IList<string> currentRoles = await _userManager.GetRolesAsync(user);
            if (currentRoles.Any(r => r == role))
                return;

            if (currentRoles.Any())
                ThrowIfIdentityFailed(await _userManager.RemoveFromRolesAsync(user, currentRoles));

            ThrowIfIdentityFailed(await _userManager.AddToRoleAsync(user, role));            
        }

        private void ThrowIfIdentityFailed(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new Exception(string.Join(" | ", result.Errors.Select(x => x.Description).ToList()));
        }
    }
}
