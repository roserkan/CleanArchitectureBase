using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Categories.Dtos;
using MediatR;
using static FastTicket.Application.Features.Categories.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { Admin, CategoryUpdate };
}
