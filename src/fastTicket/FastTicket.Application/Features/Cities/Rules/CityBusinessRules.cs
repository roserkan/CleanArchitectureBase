using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.Cities.Constants.Messages;

namespace FastTicket.Application.Features.Cities.Rules;

public class CityBusinessRules
{
    private readonly ICityRepository _cityRepository;

    public CityBusinessRules(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task CityIdShouldExist(Guid id)
    {
        City? result = await _cityRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(City_NotFound);
    }
}
