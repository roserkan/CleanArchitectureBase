using AutoMapper;
using FastTicket.Application.Features.EventGroups.Dtos;
using FastTicket.Application.Features.EventGroups.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.EventGroups.Queries.GetByIdEventGroup;

public class GetByIdEventGroupQueryHandler : IRequestHandler<GetByIdEventGroupQuery, EventGroupDto>
{
    private readonly IEventGroupRepository _eventGroupRepository;
    private readonly IMapper _mapper;
    private readonly EventGroupBusinessRules _eventGroupBusinessRules;

    public GetByIdEventGroupQueryHandler(IEventGroupRepository eventGroupRepository, IMapper mapper,
                                   EventGroupBusinessRules eventGroupBusinessRules)
    {
        _eventGroupRepository = eventGroupRepository;
        _mapper = mapper;
        _eventGroupBusinessRules = eventGroupBusinessRules;
    }


    public async Task<EventGroupDto> Handle(GetByIdEventGroupQuery request, CancellationToken cancellationToken)
    {
        await _eventGroupBusinessRules.EventGroupIdShouldExist(request.Id);

        EventGroup? eventGroup = await _eventGroupRepository.GetAsync(b => b.Id == request.Id);
        EventGroupDto eventGroupDto = _mapper.Map<EventGroupDto>(eventGroup);
        return eventGroupDto;
    }
}
