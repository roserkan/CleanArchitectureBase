using Core.Persistence.Repositories;

namespace FastTicket.Domain.Entities;

public class Venue : Entity
{
    public string Name { get; set; }
    public string LogoImagePath { get; set; }
    public string VenueImagePath { get; set; }
    public string SeatingArrangementImagePath { get; set; }

    public string Address { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public Guid CityId { get; set; }
    public City City { get; set; }
}






