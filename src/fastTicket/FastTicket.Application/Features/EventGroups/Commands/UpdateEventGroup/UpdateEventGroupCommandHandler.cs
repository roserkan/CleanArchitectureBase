using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Application.Features.EventGroups.Rules;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.EventGroups.Commands.UpdateEventGroup;

public class UpdateEventGroupCommandHandler : IRequestHandler<UpdateEventGroupCommand, UpdatedEventGroupDto>
{
    private readonly IEventGroupRepository _eventGroupRepository;
    private readonly IMapper _mapper;
    private readonly EventGroupBusinessRules _eventGroupBusinessRules;

    public UpdateEventGroupCommandHandler(IEventGroupRepository eventGroupRepository, IMapper mapper, EventGroupBusinessRules eventGroupBusinessRules)
    {
        _eventGroupRepository = eventGroupRepository;
        _mapper = mapper;
        _eventGroupBusinessRules = eventGroupBusinessRules;
    }

    public async Task<UpdatedEventGroupDto> Handle(UpdateEventGroupCommand request, CancellationToken cancellationToken)
    {
        await _eventGroupBusinessRules.EventGroupIdShouldExist(request.Id);

        EventGroup mappedEventGroup = _mapper.Map<EventGroup>(request);
        EventGroup updatedEventGroup = await _eventGroupRepository.AddAsync(mappedEventGroup);
        UpdatedEventGroupDto updatedEventGroupDto = _mapper.Map<UpdatedEventGroupDto>(updatedEventGroup);
        return updatedEventGroupDto;
    }
}
