using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IBidListService
    {
        Task<BidListModel> CreateAsync(BidListModel bidListModel);
    }
}
