using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.TicketService;

public interface ITicketService
{
    public Task<Ticket> GetByIdAsync(Guid id);
}
