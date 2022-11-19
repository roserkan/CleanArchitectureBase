using FluentValidation;

namespace FastTicket.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}
