using Core.Application.Requests;
using FastTicket.Application.Features.EventGroups.Models;
using MediatR;

namespace FastTicket.Application.Features.EventGroups.Queries.GetListEventGroup;

public class GetListEventGroupQuery : IRequest<EventGroupListModel>
{
    public PageRequest PageRequest { get; set; }
}

