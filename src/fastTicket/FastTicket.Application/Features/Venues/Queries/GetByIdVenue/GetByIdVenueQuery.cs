using FastTicket.Application.Features.Venues.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Venues.Queries.GetByIdVenue;

public class GetByIdVenueQuery : IRequest<VenueDto>
{
    public Guid Id { get; set; }
}
