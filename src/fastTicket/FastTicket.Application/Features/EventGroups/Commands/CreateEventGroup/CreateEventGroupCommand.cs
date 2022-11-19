using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.EventGroups.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.EventGroups.Constants.OperationClaims;
using FastTicket.Domain.Enums;

namespace FastTicket.Application.Features.EventGroups.Commands.CreateEventGroup;

public class CreateEventGroupCommand : IRequest<CreatedEventGroupDto>, ISecuredRequest
{
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OfficalWebSiteUrl { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string[] Roles => new[] { Admin, EventGroupAdd };
}
