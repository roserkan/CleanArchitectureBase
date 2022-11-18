using Core.Application.Requests;
using FastTicket.Application.Features.Categories.Commands.Create;
using FastTicket.Application.Features.Categories.Commands.Delete;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Features.Categories.Queries.GetByIdCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var getListCategoryQuery = new GetListCategoryQuery() { PageRequest = pageRequest };
        var result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
    {
        var result = await Mediator.Send(getByIdCategoryQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var result = await Mediator.Send(createCategoryCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        var result = await Mediator.Send(updateCategoryCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
    {
        var result = await Mediator.Send(deleteCategoryCommand);
        return Ok(result);
    }
}
