using AutoMapper;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreatedTicketDto>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly TicketBusinessRules _ticketBusinessRules;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, TicketBusinessRules ticketBusinessRules)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _ticketBusinessRules = ticketBusinessRules;
    }

    public async Task<CreatedTicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketBusinessRules.EventIdShouldExist(request.EventId);

        Ticket mappedTicket = _mapper.Map<Ticket>(request);
        Ticket createdTicket = await _ticketRepository.AddAsync(mappedTicket);
        CreatedTicketDto createdTicketDto = _mapper.Map<CreatedTicketDto>(createdTicket);
        return createdTicketDto;
    }
}