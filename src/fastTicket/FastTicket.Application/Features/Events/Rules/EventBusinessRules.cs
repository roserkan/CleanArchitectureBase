using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.EventGroupService;
using FastTicket.Application.Services.VenueService;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.Events.Constants.Messages;

namespace FastTicket.Application.Features.Events.Rules;

public class EventBusinessRules
{
    private readonly IEventRepository _eventRepository;
    private readonly IVenueService _venueService;
    private readonly IEventGroupService _eventGroupService;

    public EventBusinessRules(IEventRepository eventRepository, IVenueService venueService, IEventGroupService eventGroupService)
    {
        _eventRepository = eventRepository;
        _venueService = venueService;
        _eventGroupService = eventGroupService;
    }

    public async Task EventIdShouldExist(Guid id)
    {
        Event? result = await _eventRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(Event_NotFound);
    }

    public async Task VenueIdShouldExist(Guid venueId)
    {
        Venue? result = await _venueService.GetByIdAsync(venueId);
        if (result == null) throw new BusinessException(Event_VenueNotFound);
    }

    public async Task EventGroupIdShouldExist(Guid eventGroupId)
    {
        EventGroup? result = await _eventGroupService.GetByIdAsync(eventGroupId);
        if (result == null) throw new BusinessException(Event_EventGroupNotFound);
    }
}
