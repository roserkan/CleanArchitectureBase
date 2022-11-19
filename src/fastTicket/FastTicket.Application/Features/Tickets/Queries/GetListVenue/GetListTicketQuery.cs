using Core.Application.Requests;
using FastTicket.Application.Features.Tickets.Models;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Queries.GetListTicket;

public class GetListTicketQuery : IRequest<TicketListModel>
{
    public PageRequest PageRequest { get; set; }
}
