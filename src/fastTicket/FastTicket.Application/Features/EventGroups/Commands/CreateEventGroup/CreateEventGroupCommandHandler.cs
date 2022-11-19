using AutoMapper;
using FastTicket.Application.Features.EventGroups.Dtos;
using FastTicket.Application.Features.EventGroups.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.EventGroups.Commands.CreateEventGroup;

public class CreateEventGroupCommandHandler : IRequestHandler<CreateEventGroupCommand, CreatedEventGroupDto>
{
    private readonly IEventGroupRepository _eventGroupRepository;
    private readonly IMapper _mapper;
    private readonly EventGroupBusinessRules _eventGroupBusinessRules;

    public CreateEventGroupCommandHandler(IEventGroupRepository eventGroupRepository, IMapper mapper, EventGroupBusinessRules eventGroupBusinessRules)
    {
        _eventGroupRepository = eventGroupRepository;
        _mapper = mapper;
        _eventGroupBusinessRules = eventGroupBusinessRules;
    }

    public async Task<CreatedEventGroupDto> Handle(CreateEventGroupCommand request, CancellationToken cancellationToken)
    {
        EventGroup mappedEventGroup = _mapper.Map<EventGroup>(request);
        EventGroup createdEventGroup = await _eventGroupRepository.AddAsync(mappedEventGroup);
        CreatedEventGroupDto createdEventGroupDto = _mapper.Map<CreatedEventGroupDto>(createdEventGroup);
        return createdEventGroupDto;
    }
}
