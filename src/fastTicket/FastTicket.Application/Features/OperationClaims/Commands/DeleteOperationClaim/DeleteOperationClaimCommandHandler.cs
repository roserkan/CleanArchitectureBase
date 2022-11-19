﻿using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.OperationClaims.Dtos;
using FastTicket.Application.Features.OperationClaims.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
                                              OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request,
                                                       CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

        OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
        OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
        DeletedOperationClaimDto deletedOperationClaimDto =
            _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
        return deletedOperationClaimDto;
    }
}
