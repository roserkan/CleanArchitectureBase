using FluentValidation;

namespace FastTicket.Application.Features.EventGroups.Commands.CreateEventGroup;

public class CreateEventGroupCommandValidator : AbstractValidator<CreateEventGroupCommand>
{
    public CreateEventGroupCommandValidator()
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
