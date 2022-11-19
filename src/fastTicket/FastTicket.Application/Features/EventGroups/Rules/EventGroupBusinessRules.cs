using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.EventGroups.Constants.Messages;

namespace FastTicket.Application.Features.EventGroups.Rules;

public class EventGroupBusinessRules
{
    private readonly IEventGroupRepository _eventGroupRepository;

    public EventGroupBusinessRules(IEventGroupRepository eventGroupRepository)
    {
        _eventGroupRepository = eventGroupRepository;
    }

    public async Task EventGroupIdShouldExist(Guid id)
    {
        EventGroup? result = await _eventGroupRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(EventGroup_NotFound);
    }
}
