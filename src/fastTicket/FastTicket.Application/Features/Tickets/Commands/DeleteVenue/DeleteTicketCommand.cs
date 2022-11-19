using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Tickets.Dtos;
using MediatR;
using static FastTicket.Application.Features.Tickets.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommand : IRequest<DeletedTicketDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, TicketDelete };
}
