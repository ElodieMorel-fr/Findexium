using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ITradeRepository
    {
        Task<Trade> AddAsync(Trade trade);
    }
}
