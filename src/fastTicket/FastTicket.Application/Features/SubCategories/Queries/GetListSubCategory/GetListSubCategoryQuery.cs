using Core.Application.Requests;
using FastTicket.Application.Models.SubCategoryModels;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetListSubCategory;

public class GetListSubCategoryQuery : IRequest<SubCategoryListModel>
{
    public PageRequest PageRequest { get; set; }
}
