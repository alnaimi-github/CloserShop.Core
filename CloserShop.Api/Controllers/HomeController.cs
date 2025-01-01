using Microsoft.AspNetCore.Mvc;

namespace CloserShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()=> Ok("Hi, From Closer Shop");
}