using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class TicketCategoryRepository : EfRepositoryBase<TicketCategory, FastTicketDbContext>, ITicketCategoryRepository
{
    public TicketCategoryRepository(FastTicketDbContext context) : base(context)
    {
    }
}
