namespace FastTicket.Application.Features.Venues.Dtos;

public class UpdatedVenueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LogoImagePath { get; set; }
    public string VenueImagePath { get; set; }
    public string SeatingArrangementImagePath { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public Guid CityId { get; set; }
}
