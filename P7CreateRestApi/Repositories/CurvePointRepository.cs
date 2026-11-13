using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        private readonly LocalDbContext _dbContext;

        public CurvePointRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CurvePoint> AddAsync(CurvePoint curvePoint)
        {
            await _dbContext.CurvePoints.AddAsync(curvePoint);
            await _dbContext.SaveChangesAsync();

            return curvePoint;
        }

        public async Task<CurvePoint?> FindByIdAsync(int id)
        {
            return await _dbContext.CurvePoints.FindAsync(id);
        }

        public async Task UpdateAsync(CurvePoint curvePoint)
        {
            _dbContext.CurvePoints.Update(curvePoint);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CurvePoint curvePoint)
        {
            _dbContext.CurvePoints.Remove(curvePoint);
            await _dbContext.SaveChangesAsync();

        }
    }
}
