using Core.Application.Pipelines.Caching;
using FastTicket.Application.Features.Categories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>, ICacheRemoverRequest
{
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "category-list";
}
