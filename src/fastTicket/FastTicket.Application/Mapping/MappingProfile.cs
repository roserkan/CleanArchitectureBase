using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Features.Categories.Commands.Create;
using FastTicket.Application.Features.Categories.Commands.Delete;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Models.CategoryModels;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Categories
        CreateMap<Category, CategoryDto>()
            .ForMember(i => i.SubCategoryDto, opt => opt.MapFrom(i => i.SubCategories))
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
