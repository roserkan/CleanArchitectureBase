using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;
using FastTicket.Domain.Enums;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.EventGroups.Constants.OperationClaims;

namespace FastTicket.Application.Features.EventGroups.Commands.UpdateEventGroup;

public class UpdateEventGroupCommand : IRequest<UpdatedEventGroupDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OfficalWebSiteUrl { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string[] Roles => new[] { Admin, EventGroupUpdate };
}
