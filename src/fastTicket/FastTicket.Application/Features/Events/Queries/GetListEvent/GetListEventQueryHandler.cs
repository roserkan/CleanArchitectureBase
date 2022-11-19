using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Events.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Events.Queries.GetListEvent;

public class GetListEventQueryHandler : IRequestHandler<GetListEventQuery, EventListModel>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetListEventQueryHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventListModel> Handle(GetListEventQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Event> events = await _eventRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        EventListModel mappedEventListModel = _mapper.Map<EventListModel>(events);
        return mappedEventListModel;
    }
}

