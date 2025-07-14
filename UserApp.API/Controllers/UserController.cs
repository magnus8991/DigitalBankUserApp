using Microsoft.AspNetCore.Mvc;
using UserApp.Business;
using UserApp.Models;

namespace UserApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        _userService.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User user)
    {
        var existing = _userService.GetById(id);
        if (existing == null) return NotFound();

        user.Id = id;
        _userService.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _userService.GetById(id);
        if (existing == null) return NotFound();

        _userService.Delete(id);
        return NoContent();
    }
}