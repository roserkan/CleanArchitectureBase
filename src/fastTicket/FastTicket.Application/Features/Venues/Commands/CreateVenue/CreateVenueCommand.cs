using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Venues.Dtos;
using MediatR;
using static FastTicket.Application.Features.Venues.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Venues.Commands.CreateVenue;

public class CreateVenueCommand : IRequest<CreatedVenueDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string LogoImagePath { get; set; }
    public string VenueImagePath { get; set; }
    public string SeatingArrangementImagePath { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public Guid CityId { get; set; }
    public string[] Roles => new[] { Admin, VenueAdd };
}
