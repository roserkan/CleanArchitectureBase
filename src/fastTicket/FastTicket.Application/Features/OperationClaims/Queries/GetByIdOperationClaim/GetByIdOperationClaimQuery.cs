using FastTicket.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace FastTicket.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

public class GetByIdOperationClaimQuery : IRequest<OperationClaimDto>
{
    public Guid Id { get; set; }
}
