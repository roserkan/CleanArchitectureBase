using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.TicketCategories.Dtos;
using MediatR;
using static FastTicket.Domain.Constants.OperationClaims;
using static FastTicket.Application.Features.TicketCategories.Constants.OperationClaims;

namespace FastTicket.Application.Features.TicketCategories.Commands.DeleteTicketCategory;

public class DeleteTicketCategoryCommand : IRequest<DeletedTicketCategoryDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, TicketCategoryDelete };
}
