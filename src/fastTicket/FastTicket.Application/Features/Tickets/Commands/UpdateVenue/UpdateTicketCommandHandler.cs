using AutoMapper;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;


namespace FastTicket.Application.Features.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, UpdatedTicketDto>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly TicketBusinessRules _ticketBusinessRules;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, TicketBusinessRules ticketBusinessRules)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _ticketBusinessRules = ticketBusinessRules;
    }

    public async Task<UpdatedTicketDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketBusinessRules.TicketIdShouldExist(request.Id);
        await _ticketBusinessRules.EventIdShouldExist(request.EventId);

        Ticket mappedTicket = _mapper.Map<Ticket>(request);
        Ticket updatedTicket = await _ticketRepository.AddAsync(mappedTicket);
        UpdatedTicketDto updatedTicketDto = _mapper.Map<UpdatedTicketDto>(updatedTicket);
        return updatedTicketDto;
    }
}
