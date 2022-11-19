using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using FastTicket.Application.Features.UserOperationClaims.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
            DeletedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                  IMapper mapper,
                                                  UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
                                                           CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

        UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
        UserOperationClaim deletedUserOperationClaim =
            await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);
        DeletedUserOperationClaimDto deletedUserOperationClaimDto =
            _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
        return deletedUserOperationClaimDto;
    }
}
