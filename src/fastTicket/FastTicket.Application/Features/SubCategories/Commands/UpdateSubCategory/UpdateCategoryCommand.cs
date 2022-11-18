using FastTicket.Application.Features.SubCategories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommand : IRequest<UpdatedSubCategoryDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}
