using MediatR;
using FastTicket.Application.Features.TicketCategories.Dtos;
using Core.Application.Pipelines.Authorization;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.TicketCategories.Constants.OperationClaims;

namespace FastTicket.Application.Features.TicketCategories.Commands.UpdateTicketCategory;

public class UpdateTicketCategoryCommand : IRequest<UpdatedTicketCategoryDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid TicketId { get; set; }
    public string[] Roles => new[] { Admin, TicketCategoryUpdate };
}
