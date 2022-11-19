using Core.Application.Requests;
using FastTicket.Application.Features.Venues.Models;
using MediatR;

namespace FastTicket.Application.Features.Venues.Queries.GetListVenue;

public class GetListVenueQuery : IRequest<VenueListModel>
{
    public PageRequest PageRequest { get; set; }
}
