using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGWebAPI.Data;
using RPGWebAPI.Dtos.User;
using RPGWebAPI.Models;

namespace RPGWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepo;

    public AuthController(IAuthRepository authRepo)
    {
        _authRepo = authRepo;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(UserRegisterDto request)
    {
        ServiceResponse<int> response = await _authRepo.Register(
            new User { Username = request.Username }, request.Password
            );
        if (!response.Success) BadRequest(response);

        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(UserLoginDto request)
    {
        ServiceResponse<string> response = await _authRepo.Login(request.Username, request.Password);
        if (!response.Success) BadRequest(response);

        return Ok(response);
    }
}
