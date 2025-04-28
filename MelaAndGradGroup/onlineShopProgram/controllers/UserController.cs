using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.AspNetCore.Mvc;

namespace MelaAndGradGroup.onlineShopProgram.controllers;

[ApiController]
[Route("api/V1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await userService.FindAll());
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
    {
        User user = await userService.Register(userDTO);
        return CreatedAtAction(nameof(Register), new { id = user.id }, user);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
    {
        bool isAuthenticated = await userService.Login(userDTO.username, userDTO.password);

        if (!isAuthenticated)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok("Login successful.");
    }

}
