using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.Users.Dtos;
using MediatR;
using static FastTicket.Application.Features.Users.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;


namespace FastTicket.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>, ISecuredRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string[] Roles => new[] { Admin, UserAdd };
}
