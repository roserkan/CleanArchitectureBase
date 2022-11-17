using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, FastTicketDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(FastTicketDbContext context) : base(context)
    {
    }
}
