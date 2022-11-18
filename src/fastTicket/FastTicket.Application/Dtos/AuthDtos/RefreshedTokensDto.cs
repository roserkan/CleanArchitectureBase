using Core.Security.Entities;
using Core.Security.JWT;

namespace FastTicket.Application.Dtos.AuthDtos;

public class RefreshedTokensDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}