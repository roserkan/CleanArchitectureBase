using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.EventService;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.Tickets.Constants.Messages;

namespace FastTicket.Application.Features.Tickets.Rules;

public class TicketBusinessRules
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IEventService _eventService;

    public TicketBusinessRules(ITicketRepository ticketRepository, IEventService eventService)
    {
        _ticketRepository = ticketRepository;
        _eventService = eventService;
    }

    public async Task EventIdShouldExist(Guid id)
    {
        Event? result = await _eventService.GetByIdAsync(id);
        if (result == null) throw new BusinessException(Ticket_EventNotFound);
    }

    public async Task TicketIdShouldExist(Guid id)
    {
        Ticket? result = await _ticketRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(Ticket_NotFound);
    }
}
