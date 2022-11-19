using Core.Application.Requests;
using FastTicket.Application.Features.Performances.Commands.CreatePerformance;
using FastTicket.Application.Features.Performances.Commands.DeletePerformance;
using FastTicket.Application.Features.Performances.Commands.UpdatePerformance;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Models;
using FastTicket.Application.Features.Performances.Queries.GetByIdPerformance;
using FastTicket.Application.Features.Performances.Queries.GetListPerformance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerformancesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPerformanceQuery getListPerformanceQuery = new() { PageRequest = pageRequest };
        PerformanceListModel result = await Mediator.Send(getListPerformanceQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdPerformanceQuery getByIdPerformanceQuery)
    {
        PerformanceDto result = await Mediator.Send(getByIdPerformanceQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePerformanceCommand createPerformanceCommand)
    {
        CreatedPerformanceDto result = await Mediator.Send(createPerformanceCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePerformanceCommand updatePerformanceCommand)
    {
        UpdatedPerformanceDto result = await Mediator.Send(updatePerformanceCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePerformanceCommand deletePerformanceCommand)
    {
        DeletedPerformanceDto result = await Mediator.Send(deletePerformanceCommand);
        return Ok(result);
    }
}
