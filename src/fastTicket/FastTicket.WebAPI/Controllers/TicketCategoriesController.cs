using Core.Application.Requests;
using FastTicket.Application.Features.TicketCategories.Commands.CreateTicketCategory;
using FastTicket.Application.Features.TicketCategories.Commands.DeleteTicketCategory;
using FastTicket.Application.Features.TicketCategories.Commands.UpdateTicketCategory;
using FastTicket.Application.Features.TicketCategories.Dtos;
using FastTicket.Application.Features.TicketCategories.Models;
using FastTicket.Application.Features.TicketCategories.Queries.GetByIdTicketCategory;
using FastTicket.Application.Features.TicketCategories.Queries.GetListTicketCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketCategoriesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTicketCategoryQuery getListTicketCategoryQuery = new() { PageRequest = pageRequest };
        TicketCategoryListModel result = await Mediator.Send(getListTicketCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdTicketCategoryQuery getByIdTicketCategoryQuery)
    {
        TicketCategoryDto result = await Mediator.Send(getByIdTicketCategoryQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTicketCategoryCommand createTicketCategoryCommand)
    {
        CreatedTicketCategoryDto result = await Mediator.Send(createTicketCategoryCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTicketCategoryCommand updateTicketCategoryCommand)
    {
        UpdatedTicketCategoryDto result = await Mediator.Send(updateTicketCategoryCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteTicketCategoryCommand deleteTicketCategoryCommand)
    {
        DeletedTicketCategoryDto result = await Mediator.Send(deleteTicketCategoryCommand);
        return Ok(result);
    }
}
