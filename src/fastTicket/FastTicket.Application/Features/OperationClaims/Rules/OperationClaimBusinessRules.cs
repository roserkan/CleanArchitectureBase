using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using static FastTicket.Application.Features.OperationClaims.Constants.Messages;

namespace FastTicket.Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
    {
        OperationClaim? result = await _operationClaimRepository.GetAsync(b => b.Name == name);
        if (result == null) throw new BusinessException(OperationClaim_Name_CannotDuplicate);
    }

    public async Task OperationClaimIdShouldExistWhenSelected(Guid id)
    {
        OperationClaim? result = await _operationClaimRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(OperationClaim_NotFound);
    }
}