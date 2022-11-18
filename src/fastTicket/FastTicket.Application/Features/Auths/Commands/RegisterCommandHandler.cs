using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using FastTicket.Application.Dtos.AuthDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.AuthService;
using MediatR;

namespace FastTicket.Application.Features.Auths.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
        User newUser = new()
        {
            Email = request.UserForRegisterDto.Email,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        User createdUser = await _userRepository.AddAsync(newUser);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IPAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RegisteredDto registeredDto = new()
        { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return registeredDto;
    }
}