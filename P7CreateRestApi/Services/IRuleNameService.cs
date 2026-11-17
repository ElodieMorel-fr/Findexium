using P7CreateRestApi.Models;

namespace P7CreateRestApi.Services
{
    public interface IRuleNameService
    {
        Task<RuleNameResponse> CreateAsync(RuleNameRequest ruleNameRequest);

        Task<RuleNameResponse?> FindByIdAsync(int id);

        Task<RuleNameResponse?> UpdateAsync(int id, RuleNameRequest ruleNameRequest);
    }
}
