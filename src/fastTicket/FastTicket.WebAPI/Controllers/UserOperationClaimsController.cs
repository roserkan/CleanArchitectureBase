using Core.Application.Requests;
using FastTicket.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using FastTicket.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using FastTicket.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using FastTicket.Application.Features.UserOperationClaims.Models;
using FastTicket.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using FastTicket.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
    {
        UserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(result);
    }
}
