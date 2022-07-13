using com.opusmagus.wu.simple;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;
    private Game game;

    public GameController(ILogger<GameController> logger, Game game)
    {
        _logger = logger;
        //_logger.LogInformation("=============>GameController.Constructor() called");
        //System.IO.File.AppendAllText("./obj/api.log", "GameController constructor() called\n");
        this.game=game;
        //game.StartGame();
		var roundsToSimulate = 1;
    }

    [HttpPost(Name = "GetMap")]
    public ObjectResult Get()
    {
        //_logger.LogInformation("=============>GameController.Get() called");
        //_logger.LogInformation($"GameController.Get() called and game id=[{game.GameID}]");
        //System.IO.File.AppendAllText("./obj/api.log", "GameController.Get() called\n");
		//for(int i=0;i<roundsToSimulate;i++)	game.Tick(game.Map);
        //return Ok(new {a="hhh",b="ccc"});
        Response.Headers.AccessControlAllowOrigin="*";
        Response.Headers.AccessControlAllowHeaders="*";
        return Ok(game.Map.mapObjects);
    }

    [HttpOptions(Name = "GetMap")]
    public ActionResult GetMapOptions()
    {
        //var ok=Response;
        Response.Headers.AccessControlAllowOrigin="*";
        Response.Headers.AccessControlAllowHeaders="*";
        return Ok();
    }
}
