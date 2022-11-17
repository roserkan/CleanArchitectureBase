using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, FastTicketDbContext>, IUserRepository
{
    public UserRepository(FastTicketDbContext context) : base(context)
    {
    }
}