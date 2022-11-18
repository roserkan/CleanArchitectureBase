using FastTicket.Application.Features.Categories.Commands.Update;
using FluentValidation;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(24);
    }
}
  