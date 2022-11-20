using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.TicketCategories.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.TicketCategories.Constants.OperationClaims;

namespace FastTicket.Application.Features.TicketCategories.Commands.CreateTicketCategory;

public class CreateTicketCategoryCommand : IRequest<CreatedTicketCategoryDto>, ISecuredRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid TicketId { get; set; }
    public string[] Roles => new[] { Admin, TicketCategoryAdd };
}
