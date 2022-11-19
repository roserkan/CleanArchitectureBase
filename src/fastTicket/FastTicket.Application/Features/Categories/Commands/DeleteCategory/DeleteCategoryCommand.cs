using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Categories.Dtos;
using MediatR;
using static FastTicket.Application.Features.Categories.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string[] Roles => new[] { Admin, CategoryDelete };
}

