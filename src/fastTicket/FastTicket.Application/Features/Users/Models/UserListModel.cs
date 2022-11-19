using Core.Persistence.Paging;
using FastTicket.Application.Features.Users.Dtos;

namespace FastTicket.Application.Features.Users.Models;

public class UserListModel : BasePageableModel
{
    public IList<UserDto> Items { get; set; }
}