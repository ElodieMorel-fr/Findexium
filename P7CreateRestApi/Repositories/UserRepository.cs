using P7CreateRestApi.Data;
using P7CreateRestApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Repositories
{
    public class UserRepository
    {
        public LocalDbContext DbContext { get; }

        public UserRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
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

        public void Add(User user)
        {
        }

        public User FindById(int id)
        {
            return null;
        }
    }
}