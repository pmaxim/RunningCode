using Domain.Entities;
using System.Linq;

namespace Domain.Repositories.Concrete
{
    public class EfUserRepository : EfBaseRepository<User>, IUserRepository
    {
        public IQueryable<User> Users => Context.Users;

        public EfUserRepository(EfDbContext db) : base(db)
        {
        }
    }
}
