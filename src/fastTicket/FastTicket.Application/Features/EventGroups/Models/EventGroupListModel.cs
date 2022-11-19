using Core.Persistence.Paging;
using FastTicket.Application.Features.EventGroups.Dtos;

namespace FastTicket.Application.Features.EventGroups.Models;

public class EventGroupListModel : BasePageableModel
{
    public IList<EventGroupDto> Items { get; set; }
}

