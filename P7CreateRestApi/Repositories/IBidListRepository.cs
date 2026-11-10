using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IBidListRepository
    {
        Task<BidList> AddAsync(BidList bidList);

        Task<BidList?> FindByIdAsync(int id);
    }
}
