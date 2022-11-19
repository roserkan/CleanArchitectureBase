using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Performances.Dtos;
using MediatR;
using static FastTicket.Application.Features.Performances.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Performances.Commands.CreatePerformance;

public class CreatePerformanceCommand : IRequest<CreatedPerformanceDto>, ISecuredRequest
{
    public Guid EventId { get; set; }
    public string[] Roles => new[] { Admin, PerformanceAdd };
}