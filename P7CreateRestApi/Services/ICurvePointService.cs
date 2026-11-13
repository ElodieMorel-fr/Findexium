using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface ICurvePointService
    {
        Task<CurvePointResponse> CreateAsync(CurvePointRequest curvePointRequest);

        Task<CurvePointResponse?> FindByIdAsync(int id);

        Task<CurvePointResponse?> UpdateAsync(int id, CurvePointRequest curvePointRequest);

    }
}
