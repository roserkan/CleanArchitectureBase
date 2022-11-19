using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using MediatR;
using static FastTicket.Application.Features.UserOperationClaims.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, UserOperationClaimDelete };
}
