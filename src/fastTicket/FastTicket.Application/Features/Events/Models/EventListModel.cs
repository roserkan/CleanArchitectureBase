using Core.Persistence.Paging;
using FastTicket.Application.Features.Events.Dtos;

namespace FastTicket.Application.Features.Events.Models;

public class EventListModel : BasePageableModel
{
    public IList<EventDto> Items { get; set; }
}
