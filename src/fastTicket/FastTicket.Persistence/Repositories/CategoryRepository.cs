using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, FastTicketDbContext>, ICategoryRepository
{
    public CategoryRepository(FastTicketDbContext context) : base(context)
    {
    }
}
