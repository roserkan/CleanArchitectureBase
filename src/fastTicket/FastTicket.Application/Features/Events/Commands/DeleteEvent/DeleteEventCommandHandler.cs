using AutoMapper;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Application.Features.Events.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using FastTicket.Domain.Enums;
using MediatR;

namespace FastTicket.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, DeletedEventDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly EventBusinessRules _eventBusinessRules;

    public DeleteEventCommandHandler(IEventRepository eventRepository, IMapper mapper,
                                    EventBusinessRules eventBusinessRules)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _eventBusinessRules = eventBusinessRules;
    }

    public async Task<DeletedEventDto> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        await _eventBusinessRules.EventIdShouldExist(request.Id);
        Event mappedEvent = _mapper.Map<Event>(request);
        Event deletedEvent = await _eventRepository.DeleteAsync(mappedEvent);
        DeletedEventDto deletedEventDto = _mapper.Map<DeletedEventDto>(deletedEvent);
        return deletedEventDto;
    }
}
