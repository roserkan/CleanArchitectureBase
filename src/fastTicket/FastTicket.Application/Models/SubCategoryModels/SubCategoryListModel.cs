using Core.Persistence.Paging;
using FastTicket.Application.Dtos.SubCategoryDtos;

namespace FastTicket.Application.Models.SubCategoryModels;

public class SubCategoryListModel : BasePageableModel
{
    public IList<SubCategoryDto> Items { get; set; }
}

