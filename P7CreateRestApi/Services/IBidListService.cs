using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IBidListService
    {
        Task<BidListModel> CreateAsync(BidListModel bidListModel);

        Task<BidListModel?> FindByIdAsync(int id);

        Task<BidListModel?> UpdateAsync(int id, BidListModel bidListModel);
    }
}
