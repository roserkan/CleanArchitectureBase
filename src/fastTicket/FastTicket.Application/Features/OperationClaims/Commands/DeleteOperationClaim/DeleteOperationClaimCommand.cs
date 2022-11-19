using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.OperationClaims.Dtos;
using MediatR;
using static FastTicket.Application.Features.OperationClaims.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, OperationClaimDelete };
}
