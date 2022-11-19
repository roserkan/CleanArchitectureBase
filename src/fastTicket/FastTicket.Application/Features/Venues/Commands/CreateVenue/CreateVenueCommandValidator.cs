using FluentValidation;

namespace FastTicket.Application.Features.Venues.Commands.CreateVenue;

public class CreateVenueCommandValidator : AbstractValidator<CreateVenueCommand>
{
    public CreateVenueCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(c => c.Address)
           .NotEmpty()
           .MaximumLength(200);

        RuleFor(c => c.CityId)
          .NotEmpty();
    }
}