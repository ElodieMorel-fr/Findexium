using Microsoft.AspNetCore.Identity;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public class UserService : IUserService
    {   
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {     
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserResponse> CreateAsync(UserRequest userRequest)
        {           
            if (await _roleManager.FindByNameAsync(userRequest.Role) is null)
                throw new ArgumentException($"Rôle incorrecte : '{userRequest.Role}' n'existe pas en base!");                      

            User user = MapToEntity(userRequest);            
            IdentityResult result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)                
                throw new Exception(string.Join(" ; ", result.Errors.Select(x => x.Description).ToList()));               

            await SetOrChangeUserRoleAsync(user, userRequest.Role);

            return await MapToResponseAsync(user);
        }

        public async Task<UserResponse?> FindByIdAsync(int id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());            
            return user == null ? null : await MapToResponseAsync(user);

        }

        public async Task<UserResponse?> UpdateAsync(int id, UserRequest userRequest)
        {
            if (await _roleManager.FindByNameAsync(userRequest.Role) is null)
                throw new ArgumentException($"Rôle incorrecte : '{userRequest.Role}' n'existe pas en base!");

            User? existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
                return null;                     

            MapToEntity(userRequest, existingUser);
            IdentityResult result = await _userManager.UpdateAsync(existingUser);
            if (!result.Succeeded)
                throw new Exception(string.Join(" ; ", result.Errors.Select(x => x.Description).ToList()));

            await SetOrChangeUserRoleAsync(existingUser, userRequest.Role);

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
            if (!string.IsNullOrEmpty(userRequest.Password))
                user.PasswordHash = userRequest.Password; //TODO EML : gérer le hash
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
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                        
            IdentityResult result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
                throw new Exception(string.Join(" ; ", result.Errors.Select(x => x.Description).ToList()));
        }
    }
}
