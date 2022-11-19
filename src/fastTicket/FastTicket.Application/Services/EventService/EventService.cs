using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.EventService;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Event> GetByIdAsync(Guid id)
    {
        Event? @event = await _eventRepository.GetAsync(i => i.Id == id);
        return @event;
    }
}
