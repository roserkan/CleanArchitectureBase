using FastTicket.Application.Dtos.SubCategoryDtos;

namespace FastTicket.Application.Dtos.CategoryDtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<SubCategoryDto> SubCategoryDto { get; set; }
}
