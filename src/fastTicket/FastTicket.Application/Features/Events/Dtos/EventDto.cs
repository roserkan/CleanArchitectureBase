using FastTicket.Domain.Enums;

namespace FastTicket.Application.Features.Events.Dtos;

public class EventDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public Guid VenueId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public Guid EventGroupId { get; set; }
}


