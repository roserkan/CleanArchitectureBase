using Core.Application.Requests;
using FastTicket.Application.Features.Performances.Models;
using MediatR;

namespace FastTicket.Application.Features.Performances.Queries.GetListPerformance;

public class GetListPerformanceQuery : IRequest<PerformanceListModel>
{
    public PageRequest PageRequest { get; set; }
}
