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
        public async Task<IActionResult> AddBid([FromBody] BidListRequest bidListRequest)
        {            
            BidListResponse newBid = await _bidListService.CreateAsync(bidListRequest);
            return Ok(newBid);
        }

        [HttpGet]
        [Route("{id}")]
        
        public async Task<IActionResult> GetBidById(int id)
        {
            BidListResponse? bid = await _bidListService.FindByIdAsync(id);
            if (bid == null)
                return NotFound();
            else
                return Ok(bid);
        }

        [HttpPut]
        [Route("{id}")]
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