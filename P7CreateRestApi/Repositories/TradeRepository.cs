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

        public async Task<Trade?> FindByIdAsync(int id)
        {
            return await _dbContext.Trades.FindAsync(id);
        }

        public async Task UpdateAsync(Trade trade)
        {
            _dbContext.Trades.Update(trade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Trade trade)
        {
            _dbContext.Trades.Remove(trade);
            await _dbContext.SaveChangesAsync();

        }
    }
}
