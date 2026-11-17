using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly LocalDbContext _dbContext;

        public TradeRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }        

        public async Task<Trade> AddAsync(Trade trade)
        {
            await _dbContext.Trades.AddAsync(trade);
            await _dbContext.SaveChangesAsync();

            return trade;

        }
    }
}
