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

        public async Task<BidListResponse> CreateAsync(BidListRequest bidListRequest)
        {
            BidList bidList = MapToEntity(bidListRequest);
            bidList.CreationName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            bidList.CreationDate = DateTime.Now;
           
            await _bidListRepository.AddAsync(bidList);
            return MapToResponse(bidList);            
        }

        public async Task<BidListResponse?> FindByIdAsync(int id)
        {
            BidList? bidList = await _bidListRepository.FindByIdAsync(id);
            return bidList == null ? null : MapToResponse(bidList);
            

        }

        public async Task<BidListResponse?> UpdateAsync(int id, BidListRequest bidListRequest)
        {            
            BidList? existingBidList = await _bidListRepository.FindByIdAsync(id);
            if (existingBidList == null)
                return null;
            
            MapToEntity(bidListRequest, existingBidList);
            existingBidList.RevisionName = string.Empty;  //TODO EML : mettre le nom de l'utilisateur connecté
            existingBidList.RevisionDate = DateTime.Now;
            await _bidListRepository.UpdateAsync(existingBidList);

            return MapToResponse(existingBidList);

        }

        private static BidList MapToEntity(BidListRequest bidListRequest, BidList? bidList = null)
        {
            if (bidList == null)
                bidList = new BidList();
                        
            bidList.Account = bidListRequest.Account ?? bidList.Account;
            bidList.BidType = bidListRequest.BidType ?? bidList.BidType;
            bidList.BidQuantity = bidListRequest.BidQuantity ?? bidList.BidQuantity;
            bidList.AskQuantity = bidListRequest.AskQuantity ?? bidList.AskQuantity;
            bidList.Bid = bidListRequest.Bid ?? bidList.Bid;
            bidList.Ask = bidListRequest.Ask ?? bidList.Ask;
            bidList.Benchmark = bidListRequest.Benchmark ?? bidList.Benchmark;
            bidList.BidListDate = bidListRequest.BidListDate ?? bidList.BidListDate;
            bidList.Commentary = bidListRequest.Commentary ?? bidList.Commentary;
            bidList.BidSecurity = bidListRequest.BidSecurity ?? bidList.BidSecurity;
            bidList.BidStatus = bidListRequest.BidStatus ?? bidList.BidStatus;
            bidList.Trader = bidListRequest.Trader ?? bidList.Trader;
            bidList.Book = bidListRequest.Book ?? bidList.Book;
            bidList.DealName = bidListRequest.DealName ?? bidList.DealName;
            bidList.DealType = bidListRequest.DealType ?? bidList.DealType;
            bidList.SourceListId = bidListRequest.SourceListId ?? bidList.SourceListId;
            bidList.Side = bidListRequest.Side ?? bidList.Side;

            return bidList;
            
        }
      

        private static BidListResponse MapToResponse(BidList bidList)
        {
            return new BidListResponse()
            {
                BidListId = bidList.BidListId,
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
                CreationName = bidList.CreationName,
                CreationDate = bidList.CreationDate,
                RevisionName = bidList.RevisionName,
                RevisionDate = bidList.RevisionDate,
                DealName = bidList.DealName,
                DealType = bidList.DealType,
                SourceListId = bidList.SourceListId,
                Side = bidList.Side
            };
        }
    }
}
