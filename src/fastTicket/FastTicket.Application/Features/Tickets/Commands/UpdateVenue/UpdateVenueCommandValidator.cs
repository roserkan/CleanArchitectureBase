using FluentValidation;


namespace FastTicket.Application.Features.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(c => c.EventId)
            .NotEmpty();
    }
}