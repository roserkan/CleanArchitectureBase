using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class TicketRepository : EfRepositoryBase<Ticket, FastTicketDbContext>, ITicketRepository
{
    public TicketRepository(FastTicketDbContext context) : base(context)
    {
    }
}
