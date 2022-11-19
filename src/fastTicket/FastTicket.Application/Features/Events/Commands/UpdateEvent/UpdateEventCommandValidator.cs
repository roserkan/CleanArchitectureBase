using FluentValidation;

namespace FastTicket.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.VenueId)
            .NotEmpty();

        RuleFor(c => c.StartDate)
            .NotEmpty();

        RuleFor(c => c.EndDate)
            .NotEmpty();
    }
}
