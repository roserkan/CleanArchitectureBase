using AutoMapper;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, DeletedTicketDto>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly TicketBusinessRules _ticketBusinessRules;

    public DeleteTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, TicketBusinessRules ticketBusinessRules)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _ticketBusinessRules = ticketBusinessRules;
    }

    public async Task<DeletedTicketDto> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketBusinessRules.TicketIdShouldExist(request.Id);

        Ticket mappedTicket = _mapper.Map<Ticket>(request);
        Ticket deletedTicket = await _ticketRepository.DeleteAsync(mappedTicket);
        DeletedTicketDto deletedTicketDto = _mapper.Map<DeletedTicketDto>(deletedTicket);
        return deletedTicketDto;
    }
}