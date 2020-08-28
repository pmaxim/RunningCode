using Domain.Entities;
using System.Linq;

namespace Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IQueryable<User> Users { get; }
    }
}
