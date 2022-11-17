using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class PerformanceRepository : EfRepositoryBase<Performance, FastTicketDbContext>, IPerformanceRepository
{
    public PerformanceRepository(FastTicketDbContext context) : base(context)
    {
    }
}
