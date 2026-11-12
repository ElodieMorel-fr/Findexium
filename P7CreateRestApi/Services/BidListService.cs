using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class BidListService : IBidListService
    {
        private readonly IBidListRepository _bidListRepository;

        public BidListService(IBidListRepository bidListRepository)
        {
            _bidListRepository = bidListRepository;
        }

        public async Task<BidListModel> CreateAsync(BidListModel bidListModel)
        {
            BidList bidList = MapToEntity(bidListModel);
            bidList.CreationName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            bidList.CreationDate = DateTime.Now;
           
            bidList = await _bidListRepository.AddAsync(bidList);
            bidListModel.Id = bidList.BidListId;           

            return bidListModel;
        }

        public async Task<BidListModel?> FindByIdAsync(int id)
        {
            BidList? bidList = await _bidListRepository.FindByIdAsync(id);
            return bidList == null ? null : MapToModel(bidList);
            

        }

        public async Task<BidListModel?> UpdateAsync(int id, BidListModel bidListModel)
        {            
            BidList? existingBidList = await _bidListRepository.FindByIdAsync(id);
            if (existingBidList == null)
                return null;
            
            MapToEntity(bidListModel, existingBidList);
            existingBidList.RevisionName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            existingBidList.RevisionDate = DateTime.Now;
            await _bidListRepository.UpdateAsync(existingBidList);

            return MapToModel(existingBidList);

        }

        private static BidList MapToEntity(BidListModel bidListModel, BidList? bidList = null)
        {
            if (bidList == null)
                bidList = new BidList();
                        
            bidList.Account = bidListModel.Account;
            bidList.BidType = bidListModel.BidType;
            bidList.BidQuantity = bidListModel.BidQuantity;
            bidList.AskQuantity = bidListModel.AskQuantity;
            bidList.Bid = bidListModel.Bid;
            bidList.Ask = bidListModel.Ask;
            bidList.Benchmark = bidListModel.Benchmark;
            bidList.BidListDate = bidListModel.BidListDate;
            bidList.Commentary = bidListModel.Commentary;
            bidList.BidSecurity = bidListModel.BidSecurity;
            bidList.BidStatus = bidListModel.BidStatus;
            bidList.Trader = bidListModel.Trader;
            bidList.Book = bidListModel.Book;
            bidList.DealName = bidListModel.DealName;
            bidList.DealType = bidListModel.DealType;
            bidList.SourceListId = bidListModel.SourceListId;
            bidList.Side = bidListModel.Side;

            return bidList;
            
        }

        private static BidListModel MapToModel(BidList bidList)
        {            
            return new BidListModel()
            {
                Id = bidList.BidListId,
                Account = bidList.Account,
                BidType = bidList.BidType,
                BidQuantity = bidList.BidQuantity,
                AskQuantity = bidList.AskQuantity,
                Bid = bidList.Bid,
                Ask = bidList.Ask,
                Benchmark = bidList.Benchmark,
                BidListDate = bidList.BidListDate,
                Commentary = bidList.Commentary,
                BidSecurity = bidList.BidSecurity,
                BidStatus = bidList.BidStatus,
                Trader = bidList.Trader,
                Book = bidList.Book,               
                DealName = bidList.DealName,
                DealType = bidList.DealType,
                SourceListId = bidList.SourceListId,
                Side = bidList.Side
            };
        }
    }
}
