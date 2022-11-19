using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using static FastTicket.Application.Features.UserOperationClaims.Constants.Messages;

namespace FastTicket.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task UserOperationClaimIdShouldExistWhenSelected(Guid id)
    {
        UserOperationClaim? result = await _userOperationClaimRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(UserOperationClaim_NotFound);
    }
}