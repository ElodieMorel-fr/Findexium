using Dot.Net.WebApi.Domain;
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

        private static BidList MapToEntity(BidListModel bidListModel)
        {
            return new BidList()
            {
                Account = bidListModel.Account,
                BidType = bidListModel.BidType,
                BidQuantity = bidListModel.BidQuantity,
                AskQuantity = bidListModel.AskQuantity,
                Bid = bidListModel.Bid,
                Ask = bidListModel.Ask,
                Benchmark = bidListModel.Benchmark,
                BidListDate = bidListModel.BidListDate,
                Commentary = bidListModel.Commentary,
                BidSecurity = bidListModel.BidSecurity,
                BidStatus = bidListModel.BidStatus,
                Trader = bidListModel.Trader,
                Book = bidListModel.Book,               
                DealName = bidListModel.DealName,
                DealType = bidListModel.DealType,
                SourceListId = bidListModel.SourceListId,
                Side = bidListModel.Side
            };
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
