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
        [Route("{id}")]
        public async Task<IActionResult> GetRuleNameById(int id)
        {
            RuleNameResponse? ruleName = await _ruleNameService.FindByIdAsync(id);
            if (ruleName == null)
                return NotFound();
            else
                return Ok(ruleName);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRuleName(int id, [FromBody] RuleNameRequest ruleNameRequest)
        {
            RuleNameResponse? ruleName = await _ruleNameService.UpdateAsync(id, ruleNameRequest);
            if (ruleName == null)
                return NotFound();

            return Ok(ruleName);
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