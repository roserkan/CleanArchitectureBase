namespace FastTicket.Application.Features.SubCategories.Dtos;

public class UpdatedSubCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

