using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator>, IRepository<EmailAuthenticator>
    {
    }
}
