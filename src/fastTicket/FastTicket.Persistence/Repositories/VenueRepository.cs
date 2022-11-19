using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class VenueRepository : EfRepositoryBase<Venue, FastTicketDbContext>, IVenueRepository
{
    public VenueRepository(FastTicketDbContext context) : base(context)
    {
    }
}
