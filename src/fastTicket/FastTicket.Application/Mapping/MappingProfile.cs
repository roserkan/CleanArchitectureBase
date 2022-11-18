using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Features.Categories.Commands.Create;
using FastTicket.Application.Features.Categories.Commands.Delete;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;
using FastTicket.Application.Models.CategoryModels;
using FastTicket.Application.Models.SubCategoryModels;
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

        //SubCategories
        CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
        CreateMap<SubCategory, CreatedSubCategoryDto>().ReverseMap();
        CreateMap<SubCategory, UpdatedSubCategoryDto>().ReverseMap();
        CreateMap<SubCategory, DeletedSubCategoryDto>().ReverseMap();
        CreateMap<SubCategory, CreateSubCategoryCommand>().ReverseMap();
        CreateMap<SubCategory, UpdateSubCategoryCommand>().ReverseMap();
        CreateMap<SubCategory, DeleteSubCategoryCommand>().ReverseMap();
        CreateMap<IPaginate<SubCategory>, SubCategoryListModel>().ReverseMap();
    }
}
