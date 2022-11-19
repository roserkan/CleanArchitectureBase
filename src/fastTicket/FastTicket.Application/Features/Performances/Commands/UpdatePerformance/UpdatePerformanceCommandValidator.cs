using FluentValidation;


namespace FastTicket.Application.Features.Performances.Commands.UpdatePerformance;

public class UpdatePerformanceCommandValidator : AbstractValidator<UpdatePerformanceCommand>
{
    public UpdatePerformanceCommandValidator()
    {
        RuleFor(c => c.EventId)
            .NotEmpty();
    }
}