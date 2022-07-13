using com.opusmagus.wu.simple;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMap")]
    public ObjectResult Get()
    {
         Console.WriteLine("started...");
        var game=new Game();
        game.StartGame();
		var roundsToSimulate = 1;
		//for(int i=0;i<roundsToSimulate;i++)	game.Tick(game.Map);
        Console.WriteLine("ended.");
        return Ok(new {a="hhh",b="ccc"});
    }
}
