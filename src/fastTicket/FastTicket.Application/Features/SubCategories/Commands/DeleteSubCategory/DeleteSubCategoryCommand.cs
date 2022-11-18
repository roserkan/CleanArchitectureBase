using FastTicket.Application.Features.SubCategories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommand : IRequest<DeletedSubCategoryDto>
{
    public Guid Id { get; set; }
}


