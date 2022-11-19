using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.SubCategories.Dtos;
using MediatR;
using static FastTicket.Application.Features.SubCategories.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommand : IRequest<UpdatedSubCategoryDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string[] Roles => new[] { Admin, SubCategoryUpdate };
}
