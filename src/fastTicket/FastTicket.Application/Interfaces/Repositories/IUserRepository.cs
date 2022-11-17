using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
    }
}
