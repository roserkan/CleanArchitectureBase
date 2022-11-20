using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.TicketCategories.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.TicketCategories.Queries.GetListTicketCategory;

public class GetListTicketCategoryQueryHandler : IRequestHandler<GetListTicketCategoryQuery, TicketCategoryListModel>
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;
    private readonly IMapper _mapper;

    public GetListTicketCategoryQueryHandler(ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
        _mapper = mapper;
    }

    public async Task<TicketCategoryListModel> Handle(GetListTicketCategoryQuery request, CancellationToken cancellationToken)
    {
        IPaginate<TicketCategory> ticketCategorys = await _ticketCategoryRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        TicketCategoryListModel mappedTicketCategoryListModel = _mapper.Map<TicketCategoryListModel>(ticketCategorys);
        return mappedTicketCategoryListModel;
    }
}
