using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _ruleNameService;

        public RuleNameController(IRuleNameService ruleNameService)
        {
            _ruleNameService = ruleNameService;
        }

        [HttpPost]        
        public async Task<IActionResult> AddRuleName([FromBody]RuleNameRequest ruleNameRequest)
        {
            RuleNameResponse newRuleName = await _ruleNameService.CreateAsync(ruleNameRequest);
            return Ok(newRuleName);
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            // TODO: get RuleName by Id and to model then show to the form
            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult UpdateRuleName(int id, [FromBody] RuleName rating)
        {
            // TODO: check required fields, if valid call service to update RuleName and return RuleName list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRuleName(int id)
        {
            // TODO: Find RuleName by Id and delete the RuleName, return to Rule list
            return Ok();
        }
    }
}