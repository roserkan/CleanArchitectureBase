using FastTicket.Application.Features.SubCategories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQuery : IRequest<SubCategoryDto>
{
    public Guid Id { get; set; }
}

