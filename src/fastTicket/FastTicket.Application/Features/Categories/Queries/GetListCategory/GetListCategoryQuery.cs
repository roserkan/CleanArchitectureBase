using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using FastTicket.Application.Features.Categories.Models;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetListCategoryQuery : IRequest<CategoryListModel>
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "category-list";
    public TimeSpan? SlidingExpiration { get; }
}
