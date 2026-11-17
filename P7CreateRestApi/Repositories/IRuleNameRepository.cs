using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRuleNameRepository
    {
        Task<RuleName> AddAsync(RuleName ruleName);

        Task<RuleName?> FindByIdAsync(int id);

        Task UpdateAsync(RuleName ruleName);

        Task DeleteAsync(RuleName ruleName);
    }
}
