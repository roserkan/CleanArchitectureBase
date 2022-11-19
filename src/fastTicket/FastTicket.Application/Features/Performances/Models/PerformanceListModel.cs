using Core.Persistence.Paging;
using FastTicket.Application.Features.Performances.Dtos;

namespace FastTicket.Application.Features.Performances.Models;

public class PerformanceListModel : BasePageableModel
{
    public IList<PerformanceDto> Items { get; set; }
}
