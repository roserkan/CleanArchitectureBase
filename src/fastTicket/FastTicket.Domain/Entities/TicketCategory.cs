using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class TicketCategory : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid TicketId { get; set; }
    public virtual Ticket Ticket { get; set; }
}






