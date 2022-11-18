using Core.Persistence.Paging;
using FastTicket.Application.Features.SubCategories.Dtos;

namespace FastTicket.Application.Features.SubCategories.Models;

public class SubCategoryListModel : BasePageableModel
{
    public IList<SubCategoryDto> Items { get; set; }
}
