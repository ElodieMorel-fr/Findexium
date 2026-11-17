using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateAsync(UserRequest userRequest)
        {
            User user = MapToEntity(userRequest);            

            await _userRepository.AddAsync(user);
            return MapToResponse(user);
        }

        private static User MapToEntity(UserRequest userRequest, User? user = null)
        {
            if (user == null)
                user = new User();

            user.UserName = userRequest.UserName;
            user.Password = userRequest.Password;
            user.FullName = userRequest.FullName;
            user.Role = userRequest.Role;            

            return user;                

        }

        private static UserResponse MapToResponse(User user)
        {
            return new UserResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                FullName = user.FullName,
                Role = user.Role
                
            };
            
        }
    }
}
