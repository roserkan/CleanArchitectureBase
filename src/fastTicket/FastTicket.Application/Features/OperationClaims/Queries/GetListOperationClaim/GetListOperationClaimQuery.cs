using Core.Application.Requests;
using FastTicket.Application.Features.OperationClaims.Models;
using MediatR;

namespace FastTicket.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }
}
