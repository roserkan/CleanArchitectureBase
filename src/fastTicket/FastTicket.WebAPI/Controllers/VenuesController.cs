using Core.Application.Requests;
using FastTicket.Application.Features.Venues.Commands.CreateVenue;
using FastTicket.Application.Features.Venues.Commands.DeleteVenue;
using FastTicket.Application.Features.Venues.Commands.UpdateVenue;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Models;
using FastTicket.Application.Features.Venues.Queries.GetByIdVenue;
using FastTicket.Application.Features.Venues.Queries.GetListVenue;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VenuesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVenueQuery getListVenueQuery = new() { PageRequest = pageRequest };
        VenueListModel result = await Mediator.Send(getListVenueQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdVenueQuery getByIdVenueQuery)
    {
        VenueDto result = await Mediator.Send(getByIdVenueQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVenueCommand createVenueCommand)
    {
        CreatedVenueDto result = await Mediator.Send(createVenueCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVenueCommand updateVenueCommand)
    {
        UpdatedVenueDto result = await Mediator.Send(updateVenueCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteVenueCommand deleteVenueCommand)
    {
        DeletedVenueDto result = await Mediator.Send(deleteVenueCommand);
        return Ok(result);
    }
}
