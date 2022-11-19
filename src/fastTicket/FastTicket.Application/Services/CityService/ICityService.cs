using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.CityService;

public interface ICityService
{
    public Task<City> GetByIdAsync(Guid id);
}
