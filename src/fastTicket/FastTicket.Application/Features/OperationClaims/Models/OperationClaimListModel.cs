using Core.Persistence.Paging;
using FastTicket.Application.Features.OperationClaims.Dtos;

namespace FastTicket.Application.Features.OperationClaims.Models;

public class OperationClaimListModel : BasePageableModel
{
    public IList<OperationClaimDto> Items { get; set; }
}