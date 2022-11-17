using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{

    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }
}
