using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface ITradeService
    {
        Task<TradeResponse> CreateAsync(TradeRequest tradeRequest);

        Task<TradeResponse?> FindByIdAsync(int id);

        Task<TradeResponse?> UpdateAsync(int id, TradeRequest tradeRequest);

        Task<bool> DeleteAsync(int id);
    }
}
