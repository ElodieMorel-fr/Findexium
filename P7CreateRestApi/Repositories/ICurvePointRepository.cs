using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ICurvePointRepository
    {
        Task<CurvePoint> AddAsync(CurvePoint curvePoint);

        Task<CurvePoint?> FindByIdAsync(int id);
    }
}
