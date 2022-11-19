using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using FastTicket.Application.Interfaces.Repositories;
using static FastTicket.Application.Features.Users.Constants.Messages;

namespace FastTicket.Application.Features.Users.Rules;

public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailCannotDuplicateShouldExistWhenSelected(string email)
    {
        User? result = await _userRepository.GetAsync(b => b.Email == email);
        if (result != null) throw new BusinessException(User_Email_CannotDuplicate);
    }

    public async Task UserIdShouldExistWhenSelected(Guid id)
    {
        User? result = await _userRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(User_NotFound);
    }

    public Task UserShouldBeExist(User? user)
    {
        if (user is null) throw new BusinessException(User_NotFound);
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(User_Password_NotMatch);
        return Task.CompletedTask;
    }
}
