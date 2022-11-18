using Core.Persistence.Paging;
using FastTicket.Application.Dtos.CategoryDtos;

namespace FastTicket.Application.Models.CategoryModels;

public class CategoryListModel : BasePageableModel
{
    public IList<CategoryDto> Items { get; set; }
}
