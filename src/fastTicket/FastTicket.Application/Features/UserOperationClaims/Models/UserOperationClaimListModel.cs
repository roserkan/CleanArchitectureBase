using Core.Persistence.Paging;
using FastTicket.Application.Features.UserOperationClaims.Dtos;

namespace FastTicket.Application.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel : BasePageableModel
{
    public IList<UserOperationClaimDto> Items { get; set; }
}