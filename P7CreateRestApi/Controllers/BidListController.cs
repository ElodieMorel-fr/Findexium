using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _bidListService;
        public BidListController(IBidListService bidListService)
        {
            _bidListService = bidListService;
        }        

        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> Validate([FromBody] BidListRequest bidListRequest)
        {            
            BidListResponse newBid = await _bidListService.CreateAsync(bidListRequest);
            return Ok(newBid);
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> ShowUpdateForm(int id)
        {
            BidListResponse? bid = await _bidListService.FindByIdAsync(id);
            if (bid == null)
                return NotFound();
            else
                return Ok(bid);
        }

        [HttpPatch]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] BidListRequest bidListRequest)
        {
            // TODO: check required fields, if valid call service to update Bid and return list Bid
            BidListResponse? bid = await _bidListService.UpdateAsync(id, bidListRequest);
            if (bid == null)
                return NotFound();

            return Ok(bid);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            if(!await _bidListService.DeleteAsync(id))
                return NotFound();
            
            return Ok();
        }
    }
}