using Core.Persistence.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Interfaces.Repositories
{
    public interface ICityRepository : IAsyncRepository<City>, IRepository<City>
    {
    }
}
