﻿using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using FastTicket.Application.Features.OperationClaims.Models;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;

    public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
    }

    public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request,
                                                      CancellationToken cancellationToken)
    {
        IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                                                        index: request.PageRequest.Page,
                                                        size: request.PageRequest.PageSize);
        OperationClaimListModel mappedOperationClaimListModel =
            _mapper.Map<OperationClaimListModel>(operationClaims);
        return mappedOperationClaimListModel;
    }
}