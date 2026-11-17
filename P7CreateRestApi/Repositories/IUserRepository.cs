using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);

        Task<User?> FindByIdAsync(int id);

        Task UpdateAsync(User user);
    }
}
