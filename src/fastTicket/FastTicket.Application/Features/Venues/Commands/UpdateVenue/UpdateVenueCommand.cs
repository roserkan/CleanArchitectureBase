using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Users.Commands.UpdateUser;
using FastTicket.Application.Features.Venues.Dtos;
using MediatR;
using static FastTicket.Application.Features.Venues.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;


namespace FastTicket.Application.Features.Venues.Commands.UpdateVenue;

public class UpdateVenueCommand : IRequest<UpdatedVenueDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LogoImagePath { get; set; }
    public string VenueImagePath { get; set; }
    public string SeatingArrangementImagePath { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public Guid CityId { get; set; }
    public string[] Roles => new[] { Admin, VenueUpdate };
}
