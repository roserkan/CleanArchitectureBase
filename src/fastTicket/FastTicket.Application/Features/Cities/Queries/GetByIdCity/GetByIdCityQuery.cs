using FastTicket.Application.Features.Cities.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQuery : IRequest<CityDto>
{
    public Guid Id { get; set; }
}
