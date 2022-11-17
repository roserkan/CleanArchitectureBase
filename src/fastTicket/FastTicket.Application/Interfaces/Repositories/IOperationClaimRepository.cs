using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}
