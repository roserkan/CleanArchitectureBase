using FastTicket.Application.Features.TicketCategories.Dtos;
using MediatR;
using FastTicket.Application.Interfaces.Repositories;
using AutoMapper;
using FastTicket.Application.Features.TicketCategories.Rules;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.TicketCategories.Commands.DeleteTicketCategory;

public class DeleteTicketCategoryCommandHandler : IRequestHandler<DeleteTicketCategoryCommand, DeletedTicketCategoryDto>
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;
    private readonly IMapper _mapper;
    private readonly TicketCategoryBusinessRules _ticketCategoryBusinessRules;

    public DeleteTicketCategoryCommandHandler(ITicketCategoryRepository ticketCategoryRepository, IMapper mapper, TicketCategoryBusinessRules ticketCategoryBusinessRules)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
        _mapper = mapper;
        _ticketCategoryBusinessRules = ticketCategoryBusinessRules;
    }

    public async Task<DeletedTicketCategoryDto> Handle(DeleteTicketCategoryCommand request, CancellationToken cancellationToken)
    {
        await _ticketCategoryBusinessRules.TicketCategoryIdShouldExist(request.Id);

        TicketCategory mappedTicketCategory = _mapper.Map<TicketCategory>(request);
        TicketCategory deletedTicketCategory = await _ticketCategoryRepository.DeleteAsync(mappedTicketCategory);
        DeletedTicketCategoryDto deletedTicketCategoryDto = _mapper.Map<DeletedTicketCategoryDto>(deletedTicketCategory);
        return deletedTicketCategoryDto;
    }
}
