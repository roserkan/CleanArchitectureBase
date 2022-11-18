using FastTicket.Application.Features.Categories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
