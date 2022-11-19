using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.EventGroups.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.EventGroups.Queries.GetListEventGroup;

public class GetListEventGroupQueryHandler : IRequestHandler<GetListEventGroupQuery, EventGroupListModel>
{
    private readonly IEventGroupRepository _eventGroupRepository;
    private readonly IMapper _mapper;

    public GetListEventGroupQueryHandler(IEventGroupRepository eventGroupRepository, IMapper mapper)
    {
        _eventGroupRepository = eventGroupRepository;
        _mapper = mapper;
    }

    public async Task<EventGroupListModel> Handle(GetListEventGroupQuery request, CancellationToken cancellationToken)
    {
        IPaginate<EventGroup> eventGroups = await _eventGroupRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        EventGroupListModel mappedEventGroupListModel = _mapper.Map<EventGroupListModel>(eventGroups);
        return mappedEventGroupListModel;
    }
}

