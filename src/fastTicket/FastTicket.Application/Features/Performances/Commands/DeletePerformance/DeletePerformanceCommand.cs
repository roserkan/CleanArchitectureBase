using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Performances.Dtos;
using MediatR;
using static FastTicket.Application.Features.Performances.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Performances.Commands.DeletePerformance;

public class DeletePerformanceCommand : IRequest<DeletedPerformanceDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, PerformanceDelete };
}