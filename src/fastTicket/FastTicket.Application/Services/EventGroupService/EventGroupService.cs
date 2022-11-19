using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.EventGroupService;

public class EventGroupService : IEventGroupService
{
    private readonly IEventGroupRepository _eventGroupRepository;

    public EventGroupService(IEventGroupRepository eventGroupRepository)
    {
        _eventGroupRepository = eventGroupRepository;
    }

    public async Task<EventGroup> GetByIdAsync(Guid id)
    {
        EventGroup? eventGroup = await _eventGroupRepository.GetAsync(i => i.Id == id);
        return eventGroup;
    }
}
