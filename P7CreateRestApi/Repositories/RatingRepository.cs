using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly LocalDbContext _dbContext;

        public RatingRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rating> AddAsync(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();

            return rating;
        }

        public async Task<Rating?> FindByIdAsync(int id)
        {
            return await _dbContext.Ratings.FindAsync(id);
        }
    }
}
