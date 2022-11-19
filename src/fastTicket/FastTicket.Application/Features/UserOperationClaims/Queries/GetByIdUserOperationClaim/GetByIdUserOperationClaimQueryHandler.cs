using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using FastTicket.Application.Features.UserOperationClaims.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                 IMapper mapper,
                                                 UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }


    public async Task<UserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request,
                                                    CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

        UserOperationClaim? userOperationClaim =
            await _userOperationClaimRepository.GetAsync(b => b.Id == request.Id);
        UserOperationClaimDto userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
        return userOperationClaimDto;
    }
}
