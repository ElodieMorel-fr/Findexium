using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface ICurvePointService
    {
        Task<CurvePointResponse> CreateAsync(CurvePointRequest curvePointRequest);
    }
}
