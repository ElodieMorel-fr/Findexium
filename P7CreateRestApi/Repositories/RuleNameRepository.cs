using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class RuleNameRepository : IRuleNameRepository
    {

        private readonly LocalDbContext _dbContext;
                
        public RuleNameRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RuleName> AddAsync(RuleName ruleName)
        {
            await _dbContext.RuleNames.AddAsync(ruleName);
            await _dbContext.SaveChangesAsync();

            return ruleName;

        }
    }
}
