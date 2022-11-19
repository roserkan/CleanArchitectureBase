using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Domain.Enums;
using MediatR;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Domain.Entities;
using FastTicket.Application.Features.Events.Rules;

namespace FastTicket.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreatedEventDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly EventBusinessRules _eventBusinessRules;

    public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper,
                                    EventBusinessRules eventBusinessRules)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventBusinessRules = eventBusinessRules;
    }

    public async Task<CreatedEventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        await _eventBusinessRules.VenueIdShouldExist (request.VenueId);
        if (request.Status is null)
        {
            request.Status = EventStatusEnum.OnSale;
        }
        if (request.EventGroupId is not null)
        {
            await _eventBusinessRules.EventGroupIdShouldExist(request.VenueId);
        }
        Event mappedEvent = _mapper.Map<Event>(request);
        Event createdEvent = await _eventRepository.AddAsync(mappedEvent);
        CreatedEventDto createdEventDto = _mapper.Map<CreatedEventDto>(createdEvent);
        return createdEventDto;
    }
}
