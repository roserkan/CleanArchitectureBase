using Core.Application.Requests;
using FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;
using FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;
using FastTicket.Application.Features.SubCategories.Queries.GetByIdSubCategory;
using FastTicket.Application.Features.SubCategories.Queries.GetListSubCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var getListSubCategoryQuery = new GetListSubCategoryQuery() { PageRequest = pageRequest };
        var result = await Mediator.Send(getListSubCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdSubCategoryQuery getByIdSubCategoryQuery)
    {
        var result = await Mediator.Send(getByIdSubCategoryQuery);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSubCategoryCommand createSubCategoryCommand)
    {
        var result = await Mediator.Send(createSubCategoryCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSubCategoryCommand updateSubCategoryCommand)
    {
        var result = await Mediator.Send(updateSubCategoryCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteSubCategoryCommand deleteSubCategoryCommand)
    {
        var result = await Mediator.Send(deleteSubCategoryCommand);
        return Ok(result);
    }
}
