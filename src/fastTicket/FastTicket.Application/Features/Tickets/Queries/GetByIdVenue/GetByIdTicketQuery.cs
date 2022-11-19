using FastTicket.Application.Features.Tickets.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Queries.GetByIdTicket;

public class GetByIdTicketQuery : IRequest<TicketDto>
{
    public Guid Id { get; set; }
}
