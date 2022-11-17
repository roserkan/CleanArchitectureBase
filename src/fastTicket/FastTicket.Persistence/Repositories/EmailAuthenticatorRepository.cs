using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, FastTicketDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(FastTicketDbContext context) : base(context)
    {
    }
}
