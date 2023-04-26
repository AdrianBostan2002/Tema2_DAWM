using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class UsersRepository: RepositoryBase<User>
    {
        private readonly AppDbContext dbContext;

        public UsersRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}