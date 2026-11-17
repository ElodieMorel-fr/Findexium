using P7CreateRestApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services;
using P7CreateRestApi.Models;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

       
        [HttpPost]        
        public async Task<IActionResult> AddRating([FromBody]RatingRequest ratingRequest)
        {
            RatingResponse newRating = await _ratingService.CreateAsync(ratingRequest);
            return Ok(newRating);
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get Rating by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateRating(int id, [FromBody] Rating rating)
        {
            // TODO: check required fields, if valid call service to update Rating and return Rating list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRating(int id)
        {
            // TODO: Find Rating by Id and delete the Rating, return to Rating list
            return Ok();
        }
    }
}