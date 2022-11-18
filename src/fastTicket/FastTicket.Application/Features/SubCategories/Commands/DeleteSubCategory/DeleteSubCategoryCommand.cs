using FastTicket.Application.Dtos.SubCategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommand : IRequest<DeletedSubCategoryDto>
{
    public Guid Id { get; set; }
}


