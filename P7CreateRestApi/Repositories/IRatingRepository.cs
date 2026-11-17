using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> AddAsync(Rating rating);

        Task<Rating?> FindByIdAsync(int id);
    }
}
