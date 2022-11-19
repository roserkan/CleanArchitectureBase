using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Users.Dtos;
using MediatR;
using static FastTicket.Application.Features.Users.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeletedUserDto>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, UserDelete };
}
