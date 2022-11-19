using FastTicket.Application.Features.Performances.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Performances.Queries.GetByIdPerformance;

public class GetByIdPerformanceQuery : IRequest<PerformanceDto>
{
    public Guid Id { get; set; }
}
