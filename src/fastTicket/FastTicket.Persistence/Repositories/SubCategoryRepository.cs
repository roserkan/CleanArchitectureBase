using Core.Persistence.Repositories;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class SubCategoryRepository : EfRepositoryBase<SubCategory, FastTicketDbContext>, ISubCategoryRepository
{
    public SubCategoryRepository(FastTicketDbContext context) : base(context)
    {
    }
}
