using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.VenueService;

public interface IVenueService
{
    public Task<Venue> GetByIdAsync(Guid id);
}
