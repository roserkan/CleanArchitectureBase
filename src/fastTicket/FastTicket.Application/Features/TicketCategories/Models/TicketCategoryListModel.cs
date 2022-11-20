using Core.Persistence.Paging;
using FastTicket.Application.Features.TicketCategories.Dtos;

namespace FastTicket.Application.Features.TicketCategories.Models;

public class TicketCategoryListModel : BasePageableModel
{
    public IList<TicketCategoryDto> Items { get; set; }
}