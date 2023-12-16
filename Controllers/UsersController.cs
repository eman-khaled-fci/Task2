namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Models;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticateLogin")]
    public async Task<IActionResult> AuthenticateLogin([FromBody] AuthenticateLoginModel model)
    {
        var user = await _userService.AuthenticateLogin(model);

        if (user == null)
            return BadRequest(new { message = "Username or password is incorrect" });


        return Ok(new { Message = "Login Successfully", User = user });
    }


    [AllowAnonymous]
    [HttpPost("authenticateRegister")]
    public async Task<IActionResult> AuthenticateRegister([FromBody] AuthenticateRegisterModel model)
    {
        var user = await _userService.AuthenticateRegister(model);

        if (user == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(new { Message = "Register Successfully", User = user });
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }


}
