using Microsoft.AspNetCore.Mvc;
using UserApp.Business;
using UserApp.Models;

namespace UserApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await _service.AddUserAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        var existing = await _service.GetUserByIdAsync(id);
        if (existing == null) return NotFound();

        await _service.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetUserByIdAsync(id);
        if (existing == null) return NotFound();

        await _service.DeleteUserAsync(id);
        return NoContent();
    }
}