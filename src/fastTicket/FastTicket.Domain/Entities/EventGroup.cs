using Core.Persistence.Repositories;
using FastTicket.Domain.Enums;

namespace FastTicket.Domain.Entities;

public class EventGroup : Entity
{
    public string Name { get; set; }
    public EventStatusEnum Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OfficalWebSiteUrl { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Event> Events { get; set; }
}






