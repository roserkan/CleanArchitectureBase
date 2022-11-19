using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.EventGroups.Constants.OperationClaims;

namespace FastTicket.Application.Features.EventGroups.Commands.DeleteEventGroup;

public class DeleteEventGroupCommand : IRequest<DeletedEventGroupDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, EventGroupDelete };
}
