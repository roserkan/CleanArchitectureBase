using FastTicket.Application.Dtos.CategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
  