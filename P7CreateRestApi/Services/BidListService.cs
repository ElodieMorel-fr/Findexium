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
            var bidList = new BidList()
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
                CreationName = string.Empty, //TODO EML : mettre le nom de l'utilisateur connecté
                CreationDate = DateTime.Now,
                DealName = bidListModel.DealName,
                DealType = bidListModel.DealType,
                SourceListId = bidListModel.SourceListId,
                Side = bidListModel.Side
            };
           
            bidList = await _bidListRepository.AddAsync(bidList);
            bidListModel.Id = bidList.BidListId;           

            return bidListModel;
        }
    }
}
