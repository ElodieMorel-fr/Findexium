using P7CreateRestApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }
        
        [HttpPost]        
        public async Task<IActionResult> AddTrade([FromBody] TradeRequest tradeRequest)
        {
            TradeResponse newTrade = await _tradeService.CreateAsync(tradeRequest);
            return Ok(newTrade);
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get Trade by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateTrade(int id, [FromBody] Trade trade)
        {
            // TODO: check required fields, if valid call service to update Trade and return Trade list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTrade(int id)
        {
            // TODO: Find Trade by Id and delete the Trade, return to Trade list
            return Ok();
        }
    }
}