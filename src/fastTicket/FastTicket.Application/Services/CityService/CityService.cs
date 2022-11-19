using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.CityService;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City> GetByIdAsync(Guid id)
    {
        var city = await _cityRepository.GetAsync(i => i.Id == id);
        return city;
    }
}
