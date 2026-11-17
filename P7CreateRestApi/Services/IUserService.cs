using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateAsync(UserRequest userRequest);

        Task<UserResponse?> FindByIdAsync(int id);

        Task<UserResponse?> UpdateAsync(int id, UserRequest userRequest);

        Task<bool> DeleteAsync(int id);
    }
}
