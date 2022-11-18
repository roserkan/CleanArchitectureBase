using FastTicket.Application.Dtos.CategoryDtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
{
    public string Name { get; set; }
}
