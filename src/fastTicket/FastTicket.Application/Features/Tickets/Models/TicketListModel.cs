using Core.Persistence.Paging;
using FastTicket.Application.Features.Tickets.Dtos;

namespace FastTicket.Application.Features.Tickets.Models;

public class TicketListModel : BasePageableModel
{
    public IList<TicketDto> Items { get; set; }
}
