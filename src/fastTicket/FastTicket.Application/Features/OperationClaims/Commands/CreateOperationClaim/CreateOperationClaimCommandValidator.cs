using FluentValidation;

namespace FastTicket.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}
