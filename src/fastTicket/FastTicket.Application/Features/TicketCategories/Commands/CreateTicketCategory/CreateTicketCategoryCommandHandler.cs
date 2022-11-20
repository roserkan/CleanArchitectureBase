using FastTicket.Application.Features.TicketCategories.Dtos;
using FastTicket.Domain.Entities;
using MediatR;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Application.Features.TicketCategories.Rules;

namespace FastTicket.Application.Features.TicketCategories.Commands.CreateTicketCategory;

public class CreateTicketCategoryCommandHandler : IRequestHandler<CreateTicketCategoryCommand, CreatedTicketCategoryDto>
{
    private readonly ITicketCategoryRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly TicketCategoryBusinessRules _venueBusinessRules;

    public CreateTicketCategoryCommandHandler(ITicketCategoryRepository venueRepository, IMapper mapper, TicketCategoryBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }

    public async Task<CreatedTicketCategoryDto> Handle(CreateTicketCategoryCommand request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.TicketIdShouldExist(request.TicketId);

        TicketCategory mappedTicketCategory = _mapper.Map<TicketCategory>(request);
        TicketCategory createdTicketCategory = await _venueRepository.AddAsync(mappedTicketCategory);
        CreatedTicketCategoryDto createdTicketCategoryDto = _mapper.Map<CreatedTicketCategoryDto>(createdTicketCategory);
        return createdTicketCategoryDto;
    }
}
