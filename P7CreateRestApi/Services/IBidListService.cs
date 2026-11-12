using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IBidListService
    {
        Task<BidListResponse> CreateAsync(BidListRequest bidListRequest);

        Task<BidListResponse?> FindByIdAsync(int id);

        Task<BidListResponse?> UpdateAsync(int id, BidListRequest bidListRequest);
    }
}
