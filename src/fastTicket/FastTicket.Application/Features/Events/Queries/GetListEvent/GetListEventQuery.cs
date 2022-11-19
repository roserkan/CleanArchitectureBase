using Core.Application.Requests;
using FastTicket.Application.Features.Events.Models;
using MediatR;

namespace FastTicket.Application.Features.Events.Queries.GetListEvent;

public class GetListEventQuery : IRequest<EventListModel>
{
    public PageRequest PageRequest { get; set; }
}

