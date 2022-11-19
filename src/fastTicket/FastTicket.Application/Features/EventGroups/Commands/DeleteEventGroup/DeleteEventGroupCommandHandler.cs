using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Application.Features.EventGroups.Rules;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.EventGroups.Commands.DeleteEventGroup;

public class DeleteEventGroupCommandHandler : IRequestHandler<DeleteEventGroupCommand, DeletedEventGroupDto>
{
    private readonly IEventGroupRepository _eventGroupRepository;
    private readonly IMapper _mapper;
    private readonly EventGroupBusinessRules _eventGroupBusinessRules;

    public DeleteEventGroupCommandHandler(IEventGroupRepository eventGroupRepository, IMapper mapper, EventGroupBusinessRules eventGroupBusinessRules)
    {
        _eventGroupRepository = eventGroupRepository;
        _mapper = mapper;
        _eventGroupBusinessRules = eventGroupBusinessRules;
    }

    public async Task<DeletedEventGroupDto> Handle(DeleteEventGroupCommand request, CancellationToken cancellationToken)
    {
        await _eventGroupBusinessRules.EventGroupIdShouldExist(request.Id);

        EventGroup mappedEventGroup = _mapper.Map<EventGroup>(request);
        EventGroup deletedEventGroup = await _eventGroupRepository.DeleteAsync(mappedEventGroup);
        DeletedEventGroupDto deletedEventGroupDto = _mapper.Map<DeletedEventGroupDto>(deletedEventGroup);
        return deletedEventGroupDto;
    }
}