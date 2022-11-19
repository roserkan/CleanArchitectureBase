using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using FastTicket.Application.Features.Categories.Dtos;
using MediatR;
using static FastTicket.Application.Features.Categories.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>, ISecuredRequest, ICacheRemoverRequest
{
    public string Name { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "category-list";
    public string[] Roles => new[] { Admin, CategoryAdd};
}
