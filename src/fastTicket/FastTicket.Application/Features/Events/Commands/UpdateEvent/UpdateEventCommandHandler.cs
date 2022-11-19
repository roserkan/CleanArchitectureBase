using AutoMapper;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Application.Features.Events.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Domain.Enums;
using MediatR;

namespace FastTicket.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdatedEventDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly EventBusinessRules _eventBusinessRules;

    public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper,
                                    EventBusinessRules eventBusinessRules)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventBusinessRules = eventBusinessRules;
    }

    public async Task<UpdatedEventDto> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        await _eventBusinessRules.EventIdShouldExist(request.Id);
        await _eventBusinessRules.VenueIdShouldExist(request.VenueId);
        if (request.Status is null)
        {
            request.Status = EventStatusEnum.OnSale;
        }
        if (request.EventGroupId is not null)
        {
            await _eventBusinessRules.EventGroupIdShouldExist(request.VenueId);
        }
        Event mappedEvent = _mapper.Map<Event>(request);
        Event updatedEvent = await _eventRepository.UpdateAsync(mappedEvent);
        UpdatedEventDto updatedEventDto = _mapper.Map<UpdatedEventDto>(updatedEvent);
        return updatedEventDto;
    }
}
