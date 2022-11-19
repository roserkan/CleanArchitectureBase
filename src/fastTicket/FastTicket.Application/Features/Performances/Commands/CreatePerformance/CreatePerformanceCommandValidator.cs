using FluentValidation;

namespace FastTicket.Application.Features.Performances.Commands.CreatePerformance;

public class CreatePerformanceCommandValidator : AbstractValidator<CreatePerformanceCommand>
{
    public CreatePerformanceCommandValidator()
    {
        RuleFor(c => c.EventId)
            .NotEmpty();
    }
}