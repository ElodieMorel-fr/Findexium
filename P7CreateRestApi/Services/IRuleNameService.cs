using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IRuleNameService
    {
        Task<RuleNameResponse> CreateAsync(RuleNameRequest ruleNameRequest);
    }
}
