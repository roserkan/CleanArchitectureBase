using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using FastTicket.Application.Features.Cities.Models;
using MediatR;

namespace FastTicket.Application.Features.Cities.Queries.GetListCity;

public class GetListCityQuery : IRequest<CityListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "city-list";
    public TimeSpan? SlidingExpiration { get; }
}
