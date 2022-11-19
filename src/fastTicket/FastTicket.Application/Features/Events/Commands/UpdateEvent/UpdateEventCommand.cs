using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Domain.Enums;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.Events.Constants.OperationClaims;

namespace FastTicket.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommand : IRequest<UpdatedEventDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EventStatusEnum? Status { get; set; }
    public Guid VenueId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public Guid? EventGroupId { get; set; }
    public string[] Roles => new[] { Admin, EventUpdate };
}
