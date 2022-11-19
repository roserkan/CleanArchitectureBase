using AutoMapper;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Venues.Commands.CreateVenue;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, CreatedVenueDto>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly VenueBusinessRules _venueBusinessRules;

    public CreateVenueCommandHandler(IVenueRepository venueRepository, IMapper mapper, VenueBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }

    public async Task<CreatedVenueDto> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.CityIdShouldExist(request.CityId);

        Venue mappedVenue = _mapper.Map<Venue>(request);
        Venue createdVenue = await _venueRepository.AddAsync(mappedVenue);
        CreatedVenueDto createdVenueDto = _mapper.Map<CreatedVenueDto>(createdVenue);
        return createdVenueDto;
    }
}