using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[Controller]
public class ErrorController : ControllerBase
{
    [Route("/error-dev")]
    [HttpGet]
    public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment()) return NotFound();
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        return Problem(detail: exceptionHandlerFeature.Error.StackTrace, title: exceptionHandlerFeature.Error.Message);
    }

    [Route("/error")]
    [HttpGet]
    public IActionResult HandleError() => Problem();
}