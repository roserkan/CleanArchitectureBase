using Core.Security.Dtos;
using Core.Security.Entities;
using FastTicket.Application.Dtos.AuthDtos;
using FastTicket.Application.Features.Auths.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastTicket.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    //private readonly WebAPIConfiguration _configuration;
    //public AuthController(IConfiguration configuration)
    //{
    //    _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
    //}

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IPAddress = getIpAddress() };
        RegisteredDto result = await Mediator.Send(registerCommand);
        setRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }


    private void setRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}
