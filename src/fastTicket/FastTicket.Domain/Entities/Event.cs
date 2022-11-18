using Core.Persistence.Repositories;
using FastTicket.Domain.Enums;

namespace FastTicket.Domain.Entities;

public class Event : Entity
{
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string Rules { get; set; }
    public Guid EventGroupId { get; set; }
    public virtual EventGroup EventGroup { get; set; }
    public virtual Performance Performance { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
}






