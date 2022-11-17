using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class City : Entity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public virtual ICollection<Venue> Venues { get; set; }
}





