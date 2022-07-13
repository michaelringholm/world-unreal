using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[Controller]
[Route("/")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Get()
    {
        Redirect("/Swagger");
    }
}
