using Core.Persistence.Paging;
using FastTicket.Application.Features.Categories.Dtos;

namespace FastTicket.Application.Features.Categories.Models;

public class CategoryListModel : BasePageableModel
{
    public IList<CategoryDto> Items { get; set; }
}
