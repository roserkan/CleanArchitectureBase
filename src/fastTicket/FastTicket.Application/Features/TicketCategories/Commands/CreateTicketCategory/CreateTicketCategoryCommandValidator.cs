using FluentValidation;

namespace FastTicket.Application.Features.TicketCategories.Commands.CreateTicketCategory;

public class CreateTicketCategoryCommandValidator : AbstractValidator<CreateTicketCategoryCommand>
{
    public CreateTicketCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(80);

        RuleFor(c => c.Price)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(100000);

        RuleFor(c => c.Stock)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThan(100000);

        RuleFor(c => c.TicketId)
            .NotEmpty();
    }
}
