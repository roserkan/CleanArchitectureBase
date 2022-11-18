using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using FastTicket.Application.Features.Auths.Dtos;
using FastTicket.Application.Services.AuthService;
using FastTicket.Application.Services.UserService;
using MediatR;

namespace FastTicket.Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }
}


public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);

        LoggedDto loggedDto = new();

        if (user.AuthenticatorType is not AuthenticatorType.None)
        {
            if (request.UserForLoginDto.AuthenticatorCode is null)
            {
                await _authService.SendAuthenticatorCode(user);
                loggedDto.RequiredAuthenticatorType = user.AuthenticatorType;
                return loggedDto;
            }

            await _authService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
        }

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
        await _authService.DeleteOldRefreshTokens(user.Id);

        loggedDto.AccessToken = createdAccessToken;
        loggedDto.RefreshToken = addedRefreshToken;
        return loggedDto;
    }
}