using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LocalDbContext _dbContext;

        public UserRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //TODO EML : User management will be implemented in story 6
        /*public User FindByUserName(string userName)
        {
            return DbContext.Users.Where(user => user.UserName == userName)
                                  .FirstOrDefault();
        }*/

        //TODO EML : User management will be implemented in story 6
        /*
        public async Task<List<User>> FindAll()
        {
            return await DbContext.Users.ToListAsync();
        }*/

        public async Task<User> AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public User FindById(int id)
        {
            return null;
        }
    }
}