using FluentValidation;

namespace FastTicket.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(24);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(24);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(16);
    }
}
