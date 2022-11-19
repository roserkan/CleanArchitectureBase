using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Tickets.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Queries.GetListTicket;

public class GetListTicketQueryHandler : IRequestHandler<GetListTicketQuery, TicketListModel>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public GetListTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<TicketListModel> Handle(GetListTicketQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Ticket> tickets = await _ticketRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        TicketListModel mappedTicketListModel = _mapper.Map<TicketListModel>(tickets);
        return mappedTicketListModel;
    }
}