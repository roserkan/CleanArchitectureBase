using MediatR;
using FastTicket.Application.Features.TicketCategories.Dtos;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Application.Features.TicketCategories.Rules;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.TicketCategories.Commands.UpdateTicketCategory;

public class UpdateTicketCategoryCommandHandler : IRequestHandler<UpdateTicketCategoryCommand, UpdatedTicketCategoryDto>
{
    private readonly ITicketCategoryRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly TicketCategoryBusinessRules _venueBusinessRules;

    public UpdateTicketCategoryCommandHandler(ITicketCategoryRepository venueRepository, IMapper mapper, TicketCategoryBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }

    public async Task<UpdatedTicketCategoryDto> Handle(UpdateTicketCategoryCommand request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.TicketCategoryIdShouldExist(request.Id);
        await _venueBusinessRules.TicketIdShouldExist(request.TicketId);

        TicketCategory mappedTicketCategory = _mapper.Map<TicketCategory>(request);
        TicketCategory updatedTicketCategory = await _venueRepository.AddAsync(mappedTicketCategory);
        UpdatedTicketCategoryDto updatedTicketCategoryDto = _mapper.Map<UpdatedTicketCategoryDto>(updatedTicketCategory);
        return updatedTicketCategoryDto;
    }
}
