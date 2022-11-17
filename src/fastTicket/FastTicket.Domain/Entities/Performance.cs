using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class Performance : Entity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }

}






