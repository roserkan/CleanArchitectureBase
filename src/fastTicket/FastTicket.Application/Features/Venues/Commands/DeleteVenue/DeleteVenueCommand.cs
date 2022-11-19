using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Venues.Dtos;
using MediatR;
using static FastTicket.Application.Features.Venues.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Venues.Commands.DeleteVenue;

public class DeleteVenueCommand : IRequest<DeletedVenueDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, VenueDelete };
}
