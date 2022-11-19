using AutoMapper;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Application.Features.Events.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Events.Queries.GetByIdEvent;

public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, EventDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly EventBusinessRules _eventBusinessRules;

    public GetByIdEventQueryHandler(IEventRepository eventRepository, IMapper mapper,
                                   EventBusinessRules eventBusinessRules)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventBusinessRules = eventBusinessRules;
    }


    public async Task<EventDto> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
    {
        await _eventBusinessRules.EventIdShouldExist(request.Id);

        Event ? @event = await _eventRepository.GetAsync(b => b.Id == request.Id);
        EventDto eventDto = _mapper.Map<EventDto>(@event);
        return eventDto;
    }
}