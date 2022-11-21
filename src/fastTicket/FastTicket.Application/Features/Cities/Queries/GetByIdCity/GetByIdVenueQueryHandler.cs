using AutoMapper;
using FastTicket.Application.Features.Cities.Dtos;
using FastTicket.Application.Features.Cities.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, CityDto>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly CityBusinessRules _cityBusinessRules;

    public GetByIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper,
                                   CityBusinessRules cityBusinessRules)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _cityBusinessRules = cityBusinessRules;
    }


    public async Task<CityDto> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
    {
        await _cityBusinessRules.CityIdShouldExist(request.Id);

        City? city = await _cityRepository.GetAsync(b => b.Id == request.Id);
        CityDto cityDto = _mapper.Map<CityDto>(city);
        return cityDto;
    }
}
