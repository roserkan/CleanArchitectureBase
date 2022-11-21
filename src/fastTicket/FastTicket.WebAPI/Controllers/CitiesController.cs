using Core.Application.Requests;
using FastTicket.Application.Features.Cities.Dtos;
using FastTicket.Application.Features.Cities.Models;
using FastTicket.Application.Features.Cities.Queries.GetByIdCity;
using FastTicket.Application.Features.Cities.Queries.GetListCity;
using FastTicket.Application.Features.Venues.Queries.GetListVenue;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCityQuery getListCityQuery = new() { PageRequest = pageRequest };
        CityListModel result = await Mediator.Send(getListCityQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCityQuery getByIdCityQuery)
    {
        CityDto result = await Mediator.Send(getByIdCityQuery);
        return Ok(result);
    }
}
