using AutoMapper;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Venues.Commands.DeleteVenue;

public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand, DeletedVenueDto>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly VenueBusinessRules _venueBusinessRules;

    public DeleteVenueCommandHandler(IVenueRepository venueRepository, IMapper mapper, VenueBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }

    public async Task<DeletedVenueDto> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.VenueIdShouldExist(request.Id);

        Venue mappedVenue = _mapper.Map<Venue>(request);
        Venue deletedVenue = await _venueRepository.DeleteAsync(mappedVenue);
        DeletedVenueDto deletedVenueDto = _mapper.Map<DeletedVenueDto>(deletedVenue);
        return deletedVenueDto;
    }
}