using FastTicket.Application.Dtos.CategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
