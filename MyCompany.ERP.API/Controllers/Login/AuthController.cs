using Microsoft.AspNetCore.Mvc;
using MyCompany.Common.DTOs.Login;
using MyCompany.Common.SharedInterfaces.Login;

namespace MyCompany.ERP.API.Controllers.Login;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        if (request == null)
        {
            return BadRequest(new LoginResponseDto
            {
                Success = false,
                Message = "Request invalid"
            });
        }

        var (success, message, user) = await _authService.LoginAsync(request.UserName, request.Password);

        var response = new LoginResponseDto
        {
            Success = success,
            Message = message,
            User = user
        };

        return Ok(response);
    }
}
