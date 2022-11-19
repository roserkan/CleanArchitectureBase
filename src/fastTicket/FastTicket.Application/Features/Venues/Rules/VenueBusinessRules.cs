using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.CityService;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.Venues.Constants.Messages;

namespace FastTicket.Application.Features.Venues.Rules;

public class VenueBusinessRules
{
    private readonly IVenueRepository _venueRepository;
    private readonly ICityService _cityService;

    public VenueBusinessRules(IVenueRepository venueRepository, ICityService cityService)
    {
        _venueRepository = venueRepository;
        _cityService = cityService;
    }

    public async Task CityIdShouldExist(Guid id)
    {
        City? result = await _cityService.GetByIdAsync(id);
        if (result == null) throw new BusinessException(Venue_CityNotFound);
    }

    public async Task VenueIdShouldExist(Guid id)
    {
        Venue? result = await _venueRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(Venue_NotFound);
    }
}
