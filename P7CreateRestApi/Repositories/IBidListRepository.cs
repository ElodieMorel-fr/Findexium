using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IBidListRepository
    {
        Task<BidList> AddAsync(BidList bidList);
    }
}
