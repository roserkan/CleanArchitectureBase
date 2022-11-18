using FastTicket.Application.Dtos.SubCategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;

public class CreateSubCategoryCommand : IRequest<CreatedSubCategoryDto>
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

