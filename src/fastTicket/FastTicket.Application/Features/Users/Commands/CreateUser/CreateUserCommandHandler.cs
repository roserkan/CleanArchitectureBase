using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using FastTicket.Application.Features.Users.Dtos;
using FastTicket.Application.Features.Users.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;


namespace FastTicket.Application.Features.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper,
                                    UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User mappedUser = _mapper.Map<User>(request);
        await _userBusinessRules.UserEmailCannotDuplicateShouldExistWhenSelected(request.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;

        User createdUser = await _userRepository.AddAsync(mappedUser);
        CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
        return createdUserDto;
    }
}
