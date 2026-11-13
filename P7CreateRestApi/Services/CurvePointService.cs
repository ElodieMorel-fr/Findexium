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

        private static CurvePoint MapToEntity(CurvePointRequest curvePointRequest, CurvePoint? curvePoint = null)
        {
            if (curvePoint == null)
                curvePoint = new CurvePoint();
                        
            curvePoint.CurveId = curvePointRequest.CurveId ?? curvePoint.CurveId;
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
