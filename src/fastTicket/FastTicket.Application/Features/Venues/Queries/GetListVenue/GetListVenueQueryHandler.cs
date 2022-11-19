using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Venues.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Venues.Queries.GetListVenue;

public class GetListVenueQueryHandler : IRequestHandler<GetListVenueQuery, VenueListModel>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IMapper _mapper;

    public GetListVenueQueryHandler(IVenueRepository venueRepository, IMapper mapper)
    {
        _venueRepository = venueRepository;
        _mapper = mapper;
    }

    public async Task<VenueListModel> Handle(GetListVenueQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Venue> venues = await _venueRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        VenueListModel mappedVenueListModel = _mapper.Map<VenueListModel>(venues);
        return mappedVenueListModel;
    }
}