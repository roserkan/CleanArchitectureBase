using Core.Application.Requests;
using FastTicket.Application.Features.Events.Commands.CreateEvent;
using FastTicket.Application.Features.Events.Commands.DeleteEvent;
using FastTicket.Application.Features.Events.Commands.UpdateEvent;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Application.Features.Events.Models;
using FastTicket.Application.Features.Events.Queries.GetByIdEvent;
using FastTicket.Application.Features.Events.Queries.GetListEvent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEventQuery getListEventQuery = new() { PageRequest = pageRequest };
        EventListModel result = await Mediator.Send(getListEventQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdEventQuery getByIdEventQuery)
    {
        EventDto result = await Mediator.Send(getByIdEventQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEventCommand createEventCommand)
    {
        CreatedEventDto result = await Mediator.Send(createEventCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
    {
        UpdatedEventDto result = await Mediator.Send(updateEventCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteEventCommand deleteEventCommand)
    {
        DeletedEventDto result = await Mediator.Send(deleteEventCommand);
        return Ok(result);
    }
}
