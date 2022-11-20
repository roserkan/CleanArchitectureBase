using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.TicketService;
using FastTicket.Domain.Entities;
using static FastTicket.Application.Features.TicketCategories.Constants.Messages;

namespace FastTicket.Application.Features.TicketCategories.Rules;

public class TicketCategoryBusinessRules
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;
    private readonly ITicketService _ticketService;

    public TicketCategoryBusinessRules(ITicketCategoryRepository ticketCategoryRepository, ITicketService ticketService)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
        _ticketService = ticketService;
    }

    public async Task TicketCategoryIdShouldExist(Guid id)
    {
        TicketCategory? result = await _ticketCategoryRepository.GetAsync(i => i.Id == id);
        if (result == null) throw new BusinessException(TicketCategory_NotFound);
    }
    public async Task TicketIdShouldExist(Guid id)
    {
        Ticket? result = await _ticketService.GetByIdAsync(id);
        if (result == null) throw new BusinessException(TicketCategory_TicketNotFound);
    }
}
