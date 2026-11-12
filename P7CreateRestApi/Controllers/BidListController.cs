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
        public async Task<IActionResult> Validate([FromBody] BidListModel bidListModel)
        {            
            BidListModel newBid = await _bidListService.CreateAsync(bidListModel);
            return Ok(newBid);
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> ShowUpdateForm(int id)
        {
            BidListModel? bid = await _bidListService.FindByIdAsync(id);
            if (bid == null)
                return NotFound();
            else
                return Ok(bid);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] BidListModel bidListModel)
        {
            // TODO: check required fields, if valid call service to update Bid and return list Bid
            BidListModel? bid = await _bidListService.UpdateAsync(id, bidListModel);
            if (bid == null)
                return NotFound();

            return Ok(bid);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBid(int id)
        {
            return Ok();
        }
    }
}