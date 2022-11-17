using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class Ticket : Entity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }
    public virtual ICollection<TicketCategory> TicketCategories { get; set; }
}






