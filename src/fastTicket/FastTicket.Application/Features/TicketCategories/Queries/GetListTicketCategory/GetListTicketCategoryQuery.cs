using Core.Application.Requests;
using FastTicket.Application.Features.TicketCategories.Models;
using MediatR;

namespace FastTicket.Application.Features.TicketCategories.Queries.GetListTicketCategory;

public class GetListTicketCategoryQuery : IRequest<TicketCategoryListModel>
{
    public PageRequest PageRequest { get; set; }
}
