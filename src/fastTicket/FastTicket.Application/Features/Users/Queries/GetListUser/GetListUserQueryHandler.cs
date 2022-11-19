using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using FastTicket.Application.Features.Users.Models;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.Users.Queries.GetListUser;

public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
    {
        IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
        return mappedUserListModel;
    }
}