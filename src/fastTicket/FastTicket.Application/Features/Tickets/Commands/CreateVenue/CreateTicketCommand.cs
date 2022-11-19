using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Tickets.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.Tickets.Constants.OperationClaims;

namespace FastTicket.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommand : IRequest<CreatedTicketDto>, ISecuredRequest
{
    public Guid EventId { get; set; }
    public string[] Roles => new[] { Admin, TicketAdd };
}
