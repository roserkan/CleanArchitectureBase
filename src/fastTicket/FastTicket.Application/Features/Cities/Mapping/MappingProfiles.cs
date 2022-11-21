using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Cities.Dtos;
using FastTicket.Application.Features.Cities.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Cities.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<IPaginate<City>, CityListModel>().ReverseMap();
    }
}