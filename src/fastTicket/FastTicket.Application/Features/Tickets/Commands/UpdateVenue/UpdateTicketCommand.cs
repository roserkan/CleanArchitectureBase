using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Users.Commands.UpdateUser;
using FastTicket.Application.Features.Tickets.Dtos;
using MediatR;
using static FastTicket.Application.Features.Tickets.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;


namespace FastTicket.Application.Features.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommand : IRequest<UpdatedTicketDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string[] Roles => new[] { Admin, TicketUpdate };
}
