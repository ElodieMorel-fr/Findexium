using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class RuleNameService : IRuleNameService
    {
        private readonly IRuleNameRepository _ruleNameRepository;

        public RuleNameService(IRuleNameRepository ruleNameRepository)
        {
            _ruleNameRepository = ruleNameRepository;
        }

        public async Task<RuleNameResponse> CreateAsync(RuleNameRequest ruleNameRequest)
        {
            RuleName ruleName = MapToEntity(ruleNameRequest);       

            await _ruleNameRepository.AddAsync(ruleName);
            return MapToResponse(ruleName);
        }

        private static RuleName MapToEntity(RuleNameRequest ruleNameRequest, RuleName? ruleName = null)
        {
            if (ruleName == null)
                ruleName = new RuleName();

            ruleName.Name = ruleNameRequest.Name;
            ruleName.Description = ruleNameRequest.Description;
            ruleName.Json = ruleNameRequest.Json;
            ruleName.Template = ruleNameRequest.Template;
            ruleName.SqlStr = ruleNameRequest.SqlStr;
            ruleName.SqlPart = ruleNameRequest.SqlPart;       

            return ruleName;

        }

        private static RuleNameResponse MapToResponse(RuleName ruleName)
        {
            return new RuleNameResponse()
            {
                Id = ruleName.Id,
                Name = ruleName.Name,
                Description = ruleName.Description,
                Json = ruleName.Json,
                Template = ruleName.Template,
                SqlStr = ruleName.SqlStr,
                SqlPart = ruleName.SqlPart
               
            };

             
        }
    }
}
