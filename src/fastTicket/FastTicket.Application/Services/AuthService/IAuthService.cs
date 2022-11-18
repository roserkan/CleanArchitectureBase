using Core.Security.Entities;
using Core.Security.JWT;

namespace FastTicket.Application.Services.AuthService;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);

}
