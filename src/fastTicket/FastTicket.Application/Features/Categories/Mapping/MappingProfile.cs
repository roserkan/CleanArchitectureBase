using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Categories.Commands.Create;
using FastTicket.Application.Features.Categories.Commands.Delete;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Features.Categories.Dtos;
using FastTicket.Application.Features.Categories.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Categories.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Categories
        CreateMap<Category, CategoryDto>()
            .ForMember(i => i.SubCategories, opt => opt.MapFrom(i => i.SubCategories))
            .ReverseMap();
        CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Category, UpdatedCategoryDto>().ReverseMap();
        CreateMap<Category, DeletedCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
    }
}

