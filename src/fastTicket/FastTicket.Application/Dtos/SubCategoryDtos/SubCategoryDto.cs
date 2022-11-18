namespace FastTicket.Application.Dtos.SubCategoryDtos;

public class SubCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
}
