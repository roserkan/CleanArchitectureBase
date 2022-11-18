namespace FastTicket.Application.Features.SubCategories.Dtos;

public class SubCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

