using Core.Application.Requests;
using FastTicket.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using FastTicket.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using FastTicket.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using FastTicket.Application.Features.OperationClaims.Dtos;
using FastTicket.Application.Features.OperationClaims.Models;
using FastTicket.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using FastTicket.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
    {
        OperationClaimDto result = await Mediator.Send(getByIdOperationClaimQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(result);
    }
}
