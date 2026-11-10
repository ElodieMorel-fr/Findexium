using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class BidListRepository : IBidListRepository
    {
        private readonly LocalDbContext _dbContext;

        public BidListRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BidList> AddAsync(BidList bidList)
        {           
            await _dbContext.BidLists.AddAsync(bidList);
            await _dbContext.SaveChangesAsync();

            return bidList;

        }
    }
}
