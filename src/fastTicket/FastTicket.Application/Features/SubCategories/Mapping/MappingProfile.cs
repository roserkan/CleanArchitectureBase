using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;
using FastTicket.Application.Features.SubCategories.Dtos;
using FastTicket.Application.Features.SubCategories.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.SubCategories.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
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

