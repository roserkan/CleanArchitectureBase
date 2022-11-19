using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using FastTicket.Application.Features.UserOperationClaims.Models;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery,
            UserOperationClaimListModel>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;

    public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                 IMapper mapper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
    }

    public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request,
                                                          CancellationToken cancellationToken)
    {
        IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                                                                index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize);
        UserOperationClaimListModel mappedUserOperationClaimListModel =
            _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
        return mappedUserOperationClaimListModel;
    }
}