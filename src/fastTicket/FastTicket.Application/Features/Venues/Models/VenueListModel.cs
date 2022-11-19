using Core.Persistence.Paging;
using FastTicket.Application.Features.Venues.Dtos;

namespace FastTicket.Application.Features.Venues.Models;

public class VenueListModel : BasePageableModel
{
    public IList<VenueDto> Items { get; set; }
}