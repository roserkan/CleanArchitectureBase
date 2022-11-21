using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Cities.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Cities.Queries.GetListCity;

public class GetListCityQueryHandler : IRequestHandler<GetListCityQuery, CityListModel>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetListCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityListModel> Handle(GetListCityQuery request, CancellationToken cancellationToken)
    {
        request.PageRequest.Page = 0;
        request.PageRequest.PageSize = 81;
        IPaginate<City> cities = await _cityRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize,
                                                                   orderBy: i => i.OrderBy(i => i.Code));
        CityListModel mappedCityListModel = _mapper.Map<CityListModel>(cities);
        return mappedCityListModel;
    }
}