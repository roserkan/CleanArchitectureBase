using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.VenueService;

public class VenueService : IVenueService
{
    private readonly IVenueRepository _venueRepository;

    public VenueService(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<Venue> GetByIdAsync(Guid id)
    {
        Venue? venue = await _venueRepository.GetAsync(i => i.Id == id);
        return venue;
    }
}
