using P7CreateRestApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _curvePointService;

        public CurveController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }
       
        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> Validate([FromBody]CurvePointRequest curvePointRequest)
        {
            CurvePointResponse newCurvePoint = await _curvePointService.CreateAsync(curvePointRequest);
            return Ok(newCurvePoint);
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> ShowUpdateForm(int id)
        {
            CurvePointResponse? curvePoint = await _curvePointService.FindByIdAsync(id);
            if (curvePoint == null)
                return NotFound();
            else
                return Ok(curvePoint);
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateCurvePoint(int id, [FromBody] CurvePoint curvePoint)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBid(int id)
        {
            // TODO: Find Curve by Id and delete the Curve, return to Curve list
            return Ok();
        }
    }
}