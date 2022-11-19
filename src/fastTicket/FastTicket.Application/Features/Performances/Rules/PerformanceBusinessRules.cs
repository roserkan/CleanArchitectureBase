using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.EventService;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.Performances.Constants.Messages;

namespace FastTicket.Application.Features.Performances.Rules;

public class PerformanceBusinessRules
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IEventService _eventService;

    public PerformanceBusinessRules(IPerformanceRepository performanceRepository, IEventService eventService)
    {
        _performanceRepository = performanceRepository;
        _eventService = eventService;
    }

    public async Task PerformanceIdShouldExist(Guid id)
    {
        Performance? result = await _performanceRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(Performance_NotFound);
    }

    public async Task EventIdShouldExist(Guid eventId)
    {
        Event? result = await _eventService.GetByIdAsync(eventId);
        if (result == null) throw new BusinessException(Performance_EventNotFound);
    }
}
