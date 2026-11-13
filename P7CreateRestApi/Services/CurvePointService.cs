using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;

        public CurvePointService(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }

        public async Task<CurvePointResponse> CreateAsync(CurvePointRequest curvePointRequest)
        {
            CurvePoint curvePoint = MapToEntity(curvePointRequest);
            curvePoint.CreationDate = DateTime.Now;

            await _curvePointRepository.AddAsync(curvePoint);
            return MapToResponse(curvePoint);
        }

        public async Task<CurvePointResponse?> FindByIdAsync(int id)
        {
            CurvePoint? curvePoint = await _curvePointRepository.FindByIdAsync(id);
            return curvePoint == null ? null : MapToResponse(curvePoint);

        }

        public async Task<CurvePointResponse?> UpdateAsync(int id, CurvePointRequest curvePointRequest)
        {
            CurvePoint? existingCurvePoint = await _curvePointRepository.FindByIdAsync(id);
            if (existingCurvePoint == null)
                return null;

            MapToEntity(curvePointRequest, existingCurvePoint);
            await _curvePointRepository.UpdateAsync(existingCurvePoint);

            return MapToResponse(existingCurvePoint);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            CurvePoint? curvePoint = await _curvePointRepository.FindByIdAsync(id);
            if (curvePoint == null)
                return false;

            await _curvePointRepository.DeleteAsync(curvePoint);
            return true;

        }


        private static CurvePoint MapToEntity(CurvePointRequest curvePointRequest, CurvePoint? curvePoint = null)
        {
            if (curvePoint == null)
                curvePoint = new CurvePoint();
                        
            //curvePoint.CurveId = curvePointRequest.CurveId ?? curvePoint.CurveId; //TODO EML : à mon avis, cet identifiant n'est pas modifiable!
            curvePoint.AsOfDate = curvePointRequest.AsOfDate ?? curvePoint.AsOfDate;
            curvePoint.Term = curvePointRequest.Term ?? curvePoint.Term;
            curvePoint.CurvePointValue = curvePointRequest.CurvePointValue ?? curvePoint.CurvePointValue;

            return curvePoint;
        }

        private static CurvePointResponse MapToResponse(CurvePoint curvePoint)
        {
            return new CurvePointResponse()
            {
                Id = curvePoint.Id,
                CurveId = curvePoint.CurveId,
                AsOfDate = curvePoint.AsOfDate,
                Term = curvePoint.Term,
                CurvePointValue = curvePoint.CurvePointValue,
                CreationDate = curvePoint.CreationDate,
                
            };
        }
       
    }
}
