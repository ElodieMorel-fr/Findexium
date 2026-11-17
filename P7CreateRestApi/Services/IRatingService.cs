using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IRatingService
    {
        Task<RatingResponse> CreateAsync(RatingRequest ratingRequest);

        Task<RatingResponse?> FindByIdAsync(int id);

        Task<RatingResponse?> UpdateAsync(int id, RatingRequest ratingRequest);

        Task<bool> DeleteAsync(int id);
    }
}
