using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using FastTicket.Application.Features.UserOperationClaims.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
            UpdatedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                  IMapper mapper,
                                                  UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request,
                                                           CancellationToken cancellationToken)
    {
        UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
        UserOperationClaim updatedUserOperationClaim =
            await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
        UpdatedUserOperationClaimDto updatedUserOperationClaimDto =
            _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
        return updatedUserOperationClaimDto;
    }
}