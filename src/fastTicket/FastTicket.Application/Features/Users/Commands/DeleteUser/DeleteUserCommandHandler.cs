using AutoMapper;
using Core.Security.Entities;
using FastTicket.Application.Features.Users.Dtos;
using FastTicket.Application.Features.Users.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper,
                                    UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        User mappedUser = _mapper.Map<User>(request);
        User deletedUser = await _userRepository.DeleteAsync(mappedUser);
        DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);
        return deletedUserDto;
    }
}