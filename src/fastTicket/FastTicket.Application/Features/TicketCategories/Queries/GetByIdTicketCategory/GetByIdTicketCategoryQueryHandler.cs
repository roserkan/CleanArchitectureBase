using AutoMapper;
using FastTicket.Application.Features.TicketCategories.Dtos;
using FastTicket.Application.Features.TicketCategories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.TicketCategories.Queries.GetByIdTicketCategory;

public class GetByIdTicketCategoryQueryHandler : IRequestHandler<GetByIdTicketCategoryQuery, TicketCategoryDto>
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;
    private readonly IMapper _mapper;
    private readonly TicketCategoryBusinessRules _ticketCategoryBusinessRules;

    public GetByIdTicketCategoryQueryHandler(ITicketCategoryRepository ticketCategoryRepository, IMapper mapper,
                                   TicketCategoryBusinessRules ticketCategoryBusinessRules)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
        _mapper = mapper;
        _ticketCategoryBusinessRules = ticketCategoryBusinessRules;
    }


    public async Task<TicketCategoryDto> Handle(GetByIdTicketCategoryQuery request, CancellationToken cancellationToken)
    {
        await _ticketCategoryBusinessRules.TicketCategoryIdShouldExist(request.Id);

        TicketCategory? ticketCategory = await _ticketCategoryRepository.GetAsync(b => b.Id == request.Id);
        TicketCategoryDto ticketCategoryDto = _mapper.Map<TicketCategoryDto>(ticketCategory);
        return ticketCategoryDto;
    }
}
