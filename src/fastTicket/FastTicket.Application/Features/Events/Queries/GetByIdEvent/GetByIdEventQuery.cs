using FastTicket.Application.Features.Events.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Events.Queries.GetByIdEvent;

public class GetByIdEventQuery : IRequest<EventDto>
{
    public Guid Id { get; set; }
}
