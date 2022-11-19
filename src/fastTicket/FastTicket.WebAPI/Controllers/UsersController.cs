using Core.Application.Requests;
using FastTicket.Application.Features.Users.Commands.CreateUser;
using FastTicket.Application.Features.Users.Commands.DeleteUser;
using FastTicket.Application.Features.Users.Commands.UpdateUser;
using FastTicket.Application.Features.Users.Dtos;
using FastTicket.Application.Features.Users.Models;
using FastTicket.Application.Features.Users.Queries.GetByIdUser;
using FastTicket.Application.Features.Users.Queries.GetListUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
        UserListModel result = await Mediator.Send(getListUserQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
    {
        UserDto result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserDto result = await Mediator.Send(createUserCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserDto result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        DeletedUserDto result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }
}
