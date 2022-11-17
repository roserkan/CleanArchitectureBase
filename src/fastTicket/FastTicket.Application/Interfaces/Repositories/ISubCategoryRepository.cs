using Core.Persistence.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>, IRepository<SubCategory>
    {
    }
}
