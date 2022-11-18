using Core.Security.Entities;
using Core.Security.JWT;
using FastTicket.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FastTicket.Application.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;

    public AuthService(IRefreshTokenRepository refreshTokenRepository,
                        ITokenHelper tokenHelper,
                        IConfiguration configuration,
                        IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.UserId == user.Id)
                .Select(p => new OperationClaim
                {
                    Id = p.OperationClaimId,
                    Name = p.OperationClaim.Name
                })
                .ToListAsync();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }
}