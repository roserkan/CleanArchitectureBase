using FastTicket.Application.Features.SubCategories.Dtos;

namespace FastTicket.Application.Features.Categories.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<SubCategoryDto> SubCategories { get; set; }
}
