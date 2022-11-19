using AutoMapper;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;


namespace FastTicket.Application.Features.Venues.Commands.UpdateVenue;

public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, UpdatedVenueDto>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly VenueBusinessRules _venueBusinessRules;

    public UpdateVenueCommandHandler(IVenueRepository venueRepository, IMapper mapper, VenueBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }

    public async Task<UpdatedVenueDto> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.VenueIdShouldExist(request.Id);
        await _venueBusinessRules.CityIdShouldExist(request.CityId);

        Venue mappedVenue = _mapper.Map<Venue>(request);
        Venue updatedVenue = await _venueRepository.AddAsync(mappedVenue);
        UpdatedVenueDto updatedVenueDto = _mapper.Map<UpdatedVenueDto>(updatedVenue);
        return updatedVenueDto;
    }
}
