using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;

namespace FastTicket.Application.Dtos.AuthDtos;

public class LoggedDto : RefreshedTokensDto
{
    public AccessToken? AccessToken { get; set; }
    public RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

    public LoggedResponseDto CreateResponseDto()
    {
        return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType };
    }

    public class LoggedResponseDto
    {
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    }
}
