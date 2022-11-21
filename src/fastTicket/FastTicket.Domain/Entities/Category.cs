using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public virtual ICollection<SubCategory> SubCategories { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<EventGroup> EventGroups { get; set; }

}





