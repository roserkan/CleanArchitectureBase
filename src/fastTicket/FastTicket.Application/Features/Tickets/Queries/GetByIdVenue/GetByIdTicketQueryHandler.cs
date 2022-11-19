using AutoMapper;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Tickets.Queries.GetByIdTicket;

public class GetByIdTicketQueryHandler : IRequestHandler<GetByIdTicketQuery, TicketDto>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly TicketBusinessRules _ticketBusinessRules;

    public GetByIdTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper,
                                   TicketBusinessRules ticketBusinessRules)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _ticketBusinessRules = ticketBusinessRules;
    }


    public async Task<TicketDto> Handle(GetByIdTicketQuery request, CancellationToken cancellationToken)
    {
        await _ticketBusinessRules.TicketIdShouldExist(request.Id);

        Ticket? ticket = await _ticketRepository.GetAsync(b => b.Id == request.Id);
        TicketDto ticketDto = _mapper.Map<TicketDto>(ticket);
        return ticketDto;
    }
}
