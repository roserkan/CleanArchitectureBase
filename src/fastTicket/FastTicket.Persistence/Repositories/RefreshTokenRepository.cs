using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, FastTicketDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(FastTicketDbContext context) : base(context)
    {
    }
}
