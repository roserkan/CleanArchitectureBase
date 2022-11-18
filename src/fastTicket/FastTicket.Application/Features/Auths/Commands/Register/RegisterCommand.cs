using Core.Security.Dtos;
using FastTicket.Application.Features.Auths.Dtos;
using MediatR;

namespace FastTicket.Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IPAddress { get; set; }
}
