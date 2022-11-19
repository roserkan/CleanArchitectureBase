using AutoMapper;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Venues.Queries.GetByIdVenue;

public class GetByIdVenueQueryHandler : IRequestHandler<GetByIdVenueQuery, VenueDto>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;
    private readonly VenueBusinessRules _venueBusinessRules;

    public GetByIdVenueQueryHandler(IVenueRepository venueRepository, IMapper mapper,
                                   VenueBusinessRules venueBusinessRules)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
        _venueBusinessRules = venueBusinessRules;
    }


    public async Task<VenueDto> Handle(GetByIdVenueQuery request, CancellationToken cancellationToken)
    {
        await _venueBusinessRules.VenueIdShouldExist(request.Id);

        Venue? venue = await _venueRepository.GetAsync(b => b.Id == request.Id);
        VenueDto venueDto = _mapper.Map<VenueDto>(venue);
        return venueDto;
    }
}
