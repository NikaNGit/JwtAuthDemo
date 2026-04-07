using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public() => Ok("Публичный endpoint");

    [Authorize]
    [HttpGet("protected")]
    public IActionResult Protected() => Ok($"Привет {User.Identity?.Name}, это защищенный endpoint!");
}