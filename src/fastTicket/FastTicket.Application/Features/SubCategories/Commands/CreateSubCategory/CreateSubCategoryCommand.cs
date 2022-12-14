using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.SubCategories.Dtos;
using MediatR;
using static FastTicket.Application.Features.SubCategories.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;


namespace FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;

public class CreateSubCategoryCommand : IRequest<CreatedSubCategoryDto>, ISecuredRequest
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string[] Roles => new[] { Admin, SubCategoryAdd };
}

