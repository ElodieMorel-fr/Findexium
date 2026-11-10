using P7CreateRestApi.Domain;
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

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateBid(int id, [FromBody] BidList bidList)
        {
            // TODO: check required fields, if valid call service to update Bid and return list Bid
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBid(int id)
        {
            return Ok();
        }
    }
}