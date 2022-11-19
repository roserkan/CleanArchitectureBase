using Core.Application.Requests;
using FastTicket.Application.Features.Users.Models;
using MediatR;

namespace FastTicket.Application.Features.Users.Queries.GetListUser;

public class GetListUserQuery : IRequest<UserListModel>
{
    public PageRequest PageRequest { get; set; }
}
