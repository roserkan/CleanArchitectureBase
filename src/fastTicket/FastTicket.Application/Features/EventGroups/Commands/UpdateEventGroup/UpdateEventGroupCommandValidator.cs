using FluentValidation;

namespace FastTicket.Application.Features.EventGroups.Commands.UpdateEventGroup;

public class UpdateEventGroupCommandValidator : AbstractValidator<UpdateEventGroupCommand>
{
    public UpdateEventGroupCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(c => c.StartDate)
           .NotEmpty();

        RuleFor(c => c.EndDate)
          .NotEmpty();
    }
}