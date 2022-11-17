using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, FastTicketDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(FastTicketDbContext context) : base(context)
    {
    }
}
