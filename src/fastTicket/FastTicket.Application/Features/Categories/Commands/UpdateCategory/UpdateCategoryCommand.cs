using FastTicket.Application.Features.Categories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
  