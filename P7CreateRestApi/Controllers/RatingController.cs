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
        [Route("{id}")]
        public async Task<IActionResult> GetRatingByID(int id)
        {
            RatingResponse? rating = await _ratingService.FindByIdAsync(id);
            if (rating == null)
                return NotFound();
            else
                return Ok(rating);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingRequest ratingRequest)
        {
            // TODO: check required fields, if valid call service to update Rating and return Rating list
            RatingResponse? rating = await _ratingService.UpdateAsync(id, ratingRequest);
            if (rating == null)
                return NotFound();

            return Ok(rating);
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