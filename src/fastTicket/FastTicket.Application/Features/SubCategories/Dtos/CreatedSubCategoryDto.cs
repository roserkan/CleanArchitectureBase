namespace FastTicket.Application.Features.SubCategories.Dtos;

public class CreatedSubCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

