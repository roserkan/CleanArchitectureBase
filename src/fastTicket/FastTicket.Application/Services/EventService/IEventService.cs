using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.EventService;

public interface IEventService
{
    public Task<Event> GetByIdAsync(Guid id);
}
