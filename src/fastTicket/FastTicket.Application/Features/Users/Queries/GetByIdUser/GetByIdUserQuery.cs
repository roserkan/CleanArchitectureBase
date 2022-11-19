using FastTicket.Application.Features.Users.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Users.Queries.GetByIdUser;

public class GetByIdUserQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}
