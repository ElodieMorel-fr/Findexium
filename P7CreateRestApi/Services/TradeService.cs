using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class TradeService : ITradeService
    {      
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task<TradeResponse> CreateAsync(TradeRequest tradeRequest)
        {
            Trade trade = MapToEntity(tradeRequest);
            trade.CreationName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            trade.CreationDate = DateTime.Now;

            await _tradeRepository.AddAsync(trade);
            return MapToResponse(trade);
        }

        public async Task<TradeResponse?> FindByIdAsync(int id)
        {
            Trade? trade = await _tradeRepository.FindByIdAsync(id);
            return trade == null ? null : MapToResponse(trade);

        }

        public async Task<TradeResponse?> UpdateAsync(int id, TradeRequest tradeRequest)
        {
            Trade? existingTrade = await _tradeRepository.FindByIdAsync(id);
            if (existingTrade == null)
                return null;

            MapToEntity(tradeRequest, existingTrade);
            existingTrade.RevisionName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            existingTrade.RevisionDate = DateTime.Now;
            await _tradeRepository.UpdateAsync(existingTrade);

            return MapToResponse(existingTrade);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            Trade? trade = await _tradeRepository.FindByIdAsync(id);
            if (trade == null)
                return false;

            await _tradeRepository.DeleteAsync(trade);
            return true;

        }

        private static Trade MapToEntity(TradeRequest tradeRequest, Trade? trade = null)
        {
            if (trade == null)
                trade = new Trade();

            trade.Account = tradeRequest.Account;
            trade.AccountType = tradeRequest.AccountType;
            trade.BuyQuantity = tradeRequest.BuyQuantity;
            trade.SellQuantity = tradeRequest.SellQuantity;
            trade.BuyPrice = tradeRequest.BuyPrice;
            trade.SellPrice = tradeRequest.SellPrice;
            trade.TradeDate = tradeRequest.TradeDate;
            trade.TradeSecurity = tradeRequest.TradeSecurity;
            trade.TradeStatus = tradeRequest.TradeStatus;
            trade.Trader = tradeRequest.Trader;
            trade.Benchmark = tradeRequest.Benchmark;
            trade.Book = tradeRequest.Book;
            trade.DealName = tradeRequest.DealName;
            trade.DealType = tradeRequest.DealType;
            trade.SourceListId = tradeRequest.SourceListId;
            trade.Side = tradeRequest.Side;
         
            return trade;

        }

        private static TradeResponse MapToResponse(Trade trade)
        {
            return new TradeResponse()
            {
                TradeId = trade.TradeId,
                Account = trade.Account,
                AccountType = trade.AccountType,
                BuyQuantity = trade.BuyQuantity,
                SellQuantity = trade.SellQuantity,
                BuyPrice = trade.BuyPrice,
                SellPrice = trade.SellPrice,
                TradeDate = trade.TradeDate,
                TradeSecurity = trade.TradeSecurity,
                TradeStatus = trade.TradeStatus,
                Trader = trade.Trader,
                Benchmark = trade.Benchmark,
                Book = trade.Book,
                CreationName = trade.CreationName,
                CreationDate = trade.CreationDate,
                RevisionName = trade.RevisionName,
                RevisionDate = trade.RevisionDate,
                DealName = trade.DealName,
                DealType = trade.DealType,
                SourceListId = trade.SourceListId,
                Side = trade.Side                
              
            };
            
        }
    }
}
