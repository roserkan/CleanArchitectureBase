using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, FastTicketDbContext>, ICityRepository
{
    public CityRepository(FastTicketDbContext context) : base(context)
    {
    }
}
