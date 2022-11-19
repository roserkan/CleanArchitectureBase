using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;

namespace FastTicket.Application.Features.EventGroups.Queries.GetByIdEventGroup;

public class GetByIdEventGroupQuery : IRequest<EventGroupDto>
{
    public Guid Id { get; set; }
}
