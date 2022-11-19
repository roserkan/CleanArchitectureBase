using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Performances.Commands.CreatePerformance;
using FastTicket.Application.Features.Performances.Commands.DeletePerformance;
using FastTicket.Application.Features.Performances.Commands.UpdatePerformance;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Performances.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Performance, CreatePerformanceCommand>().ReverseMap();
        CreateMap<Performance, CreatedPerformanceDto>().ReverseMap();
        CreateMap<Performance, UpdatePerformanceCommand>().ReverseMap();
        CreateMap<Performance, UpdatedPerformanceDto>().ReverseMap();
        CreateMap<Performance, DeletePerformanceCommand>().ReverseMap();
        CreateMap<Performance, DeletedPerformanceDto>().ReverseMap();
        CreateMap<Performance, PerformanceDto>().ReverseMap();
        CreateMap<IPaginate<Performance>, PerformanceListModel>().ReverseMap();
    }
}
