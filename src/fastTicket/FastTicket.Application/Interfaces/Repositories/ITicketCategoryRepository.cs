using Core.Persistence.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface ITicketCategoryRepository : IAsyncRepository<TicketCategory>, IRepository<TicketCategory>
    {
    }
}
