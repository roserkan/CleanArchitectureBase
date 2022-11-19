using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.OperationClaims.Dtos;
using FastTicket.Application.Features.OperationClaims.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
                                              OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request,
                                                       CancellationToken cancellationToken)
    {
        OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
        OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
        UpdatedOperationClaimDto updatedOperationClaimDto =
            _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
        return updatedOperationClaimDto;
    }
}
