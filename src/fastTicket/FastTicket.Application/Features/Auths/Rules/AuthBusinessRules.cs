using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using FastTicket.Application.Interfaces.Repositories;
using static FastTicket.Application.Features.Auths.Constants.Messages;

namespace FastTicket.Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user != null) throw new BusinessException(Auth_Email_CannotDuplicate);
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user == null) throw new BusinessException(Auth_NotFound);
        return Task.CompletedTask;
    }

    public async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(Auth_Password_NotMatch);
    }
}
