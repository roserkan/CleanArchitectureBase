using FastTicket.Application.Features.TicketCategories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.TicketCategories.Queries.GetByIdTicketCategory;

public class GetByIdTicketCategoryQuery : IRequest<TicketCategoryDto>
{
    public Guid Id { get; set; }
}
