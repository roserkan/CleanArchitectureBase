using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.EventGroupService;

public interface IEventGroupService
{
    public Task<EventGroup> GetByIdAsync(Guid id);
}
