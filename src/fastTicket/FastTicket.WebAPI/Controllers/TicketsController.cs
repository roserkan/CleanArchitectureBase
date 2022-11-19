using Core.Application.Requests;
using FastTicket.Application.Features.Tickets.Commands.CreateTicket;
using FastTicket.Application.Features.Tickets.Commands.DeleteTicket;
using FastTicket.Application.Features.Tickets.Commands.UpdateTicket;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Models;
using FastTicket.Application.Features.Tickets.Queries.GetByIdTicket;
using FastTicket.Application.Features.Tickets.Queries.GetListTicket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTicketQuery getListTicketQuery = new() { PageRequest = pageRequest };
        TicketListModel result = await Mediator.Send(getListTicketQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdTicketQuery getByIdTicketQuery)
    {
        TicketDto result = await Mediator.Send(getByIdTicketQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTicketCommand createTicketCommand)
    {
        CreatedTicketDto result = await Mediator.Send(createTicketCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTicketCommand updateTicketCommand)
    {
        UpdatedTicketDto result = await Mediator.Send(updateTicketCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteTicketCommand deleteTicketCommand)
    {
        DeletedTicketDto result = await Mediator.Send(deleteTicketCommand);
        return Ok(result);
    }
}
