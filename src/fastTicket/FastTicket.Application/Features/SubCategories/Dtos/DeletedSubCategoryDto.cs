namespace FastTicket.Application.Features.SubCategories.Dtos;

public class DeletedSubCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}

