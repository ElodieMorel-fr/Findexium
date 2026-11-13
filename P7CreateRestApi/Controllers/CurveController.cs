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

        [HttpPatch]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateCurvePoint(int id, [FromBody] CurvePointRequest curvePointRequest)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            CurvePointResponse? curvePoint = await _curvePointService.UpdateAsync(id, curvePointRequest);
            if (curvePoint == null)
                return NotFound();

            return Ok(curvePoint);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            if (!await _curvePointService.DeleteAsync(id))
                return NotFound();

            return Ok();
        }
    }
}