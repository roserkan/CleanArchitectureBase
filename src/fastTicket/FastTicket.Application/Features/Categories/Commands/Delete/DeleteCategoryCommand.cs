using FastTicket.Application.Dtos.CategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryDto>
{
    public Guid Id { get; set; }
}

