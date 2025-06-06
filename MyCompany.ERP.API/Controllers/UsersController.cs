using Microsoft.AspNetCore.Mvc;
using MyCompany.Common.DTOs.Users;
using MyCompany.ERP.API.Services.Login;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto user)
    {
        if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("UserName and Password cannot be null or empty.");
        }

        await _userRepository.AddUserAsync(user.UserName, user.Password);
        return Ok();
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto user)
    {
        if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("UserName and Password cannot be null or empty.");
        }

        await _userRepository.UpdateUserAsync(id, user.UserName, user.Password);
        return Ok();
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userRepository.DeleteUserAsync(id);
        return Ok();
    }
}