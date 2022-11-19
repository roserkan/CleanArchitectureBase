using FastTicket.Domain.Enums;

namespace FastTicket.Application.Features.EventGroups.Dtos;

public class EventGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OfficalWebSiteUrl { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
}

