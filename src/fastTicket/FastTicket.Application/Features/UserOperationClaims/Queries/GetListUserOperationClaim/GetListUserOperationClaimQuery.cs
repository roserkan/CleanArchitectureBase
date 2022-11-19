using Core.Application.Requests;
using FastTicket.Application.Features.UserOperationClaims.Models;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }
}
