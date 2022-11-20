using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.TicketService;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _venueRepository;

    public TicketService(ITicketRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<Ticket> GetByIdAsync(Guid id)
    {
        Ticket? venue = await _venueRepository.GetAsync(i => i.Id == id);
        return venue;
    }
}
