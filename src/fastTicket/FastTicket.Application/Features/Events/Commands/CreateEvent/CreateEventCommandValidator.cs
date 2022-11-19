using FluentValidation;

namespace FastTicket.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
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