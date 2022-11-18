using FastTicket.Application.Dtos.SubCategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQuery : IRequest<SubCategoryDto>
{
    public Guid Id { get; set; }
}

