using Core.Persistence.Paging;
using FastTicket.Application.Features.Cities.Dtos;

namespace FastTicket.Application.Features.Cities.Models;

public class CityListModel : BasePageableModel
{
    public IList<CityDto> Items { get; set; }
}
