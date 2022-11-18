using FastTicket.Application.Features.Categories.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryDto>
{
    public string Name { get; set; }
}
