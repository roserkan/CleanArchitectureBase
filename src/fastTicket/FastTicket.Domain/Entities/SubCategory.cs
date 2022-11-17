using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class SubCategory : Entity
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
}





