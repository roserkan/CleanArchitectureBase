using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Performances.Dtos;
using MediatR;
using static FastTicket.Application.Features.Performances.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;


namespace FastTicket.Application.Features.Performances.Commands.UpdatePerformance;

public class UpdatePerformanceCommand : IRequest<UpdatedPerformanceDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string[] Roles => new[] { Admin, PerformanceUpdate };
}
