using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Events.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.Events.Constants.OperationClaims;

namespace FastTicket.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommand : IRequest<DeletedEventDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, EventDelete };
}
