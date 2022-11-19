using FastTicket.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimDto>
{
    public Guid Id { get; set; }
}
