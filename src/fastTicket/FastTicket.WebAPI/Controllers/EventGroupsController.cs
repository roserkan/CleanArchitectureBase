using Core.Application.Requests;
using FastTicket.Application.Features.EventGroups.Commands.CreateEventGroup;
using FastTicket.Application.Features.EventGroups.Commands.DeleteEventGroup;
using FastTicket.Application.Features.EventGroups.Commands.UpdateEventGroup;
using FastTicket.Application.Features.EventGroups.Dtos;
using FastTicket.Application.Features.EventGroups.Models;
using FastTicket.Application.Features.EventGroups.Queries.GetByIdEventGroup;
using FastTicket.Application.Features.EventGroups.Queries.GetListEventGroup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventGroupsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEventGroupQuery getListEventGroupQuery = new() { PageRequest = pageRequest };
        EventGroupListModel result = await Mediator.Send(getListEventGroupQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdEventGroupQuery getByIdEventGroupQuery)
    {
        EventGroupDto result = await Mediator.Send(getByIdEventGroupQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEventGroupCommand createEventGroupCommand)
    {
        CreatedEventGroupDto result = await Mediator.Send(createEventGroupCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEventGroupCommand updateEventGroupCommand)
    {
        UpdatedEventGroupDto result = await Mediator.Send(updateEventGroupCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteEventGroupCommand deleteEventGroupCommand)
    {
        DeletedEventGroupDto result = await Mediator.Send(deleteEventGroupCommand);
        return Ok(result);
    }
}
