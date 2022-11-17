using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class EventRepository : EfRepositoryBase<Event, FastTicketDbContext>, IEventRepository
{
    public EventRepository(FastTicketDbContext context) : base(context)
    {
    }
}
