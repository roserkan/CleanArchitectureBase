namespace FastTicket.Application.Features.TicketCategories.Dtos;

public class CreatedTicketCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid TicketId { get; set; }
}

