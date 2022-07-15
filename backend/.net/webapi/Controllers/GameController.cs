using com.opusmagus.wu.simple;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace webapi.Controllers;

[ApiController]
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

    [Route("/api/game/map")]
    //[HttpPost(Name = "GetMap")]
    [HttpPost,HttpOptions]
    public ActionResult GetMap()
    {
        //_logger.LogInformation("=============>GameController.Get() called");
        //_logger.LogInformation($"GameController.Get() called and game id=[{game.GameID}]");
        //System.IO.File.AppendAllText("./obj/api.log", "GameController.Get() called\n");
		//for(int i=0;i<roundsToSimulate;i++)	game.Tick(game.Map);
        //return Ok(new {a="hhh",b="ccc"});
        
        Response.Headers.AccessControlAllowOrigin="*";
        Response.Headers.AccessControlAllowHeaders="*";
        // Swagger does not like two methods with same route even if HTTP method is different
        if(Response.HttpContext.Request.Method==HttpMethod.Options.ToString()) return Ok(); 
        //return Ok( new { mapObjects=game.Map.mapObjects, mapActionObjects=game.Map.mapObjects.Where(mo=>mo is (MapActionObject<mo.GetType()>)).Cast<MapActionObject<Type>>() });
        return Ok( new { gameID=game.GameID, xTiles=game.Map.xTiles, yTiles=game.Map.yTiles });
        //return Ok( game.Map.mapObjects.Cast<Object>() );
    }

    [Route("/api/game/map-details")]
    [HttpPost,HttpOptions]
    public ActionResult GetMapObjects()
    {
        //_logger.LogInformation("=============>GameController.Get() called");
        //_logger.LogInformation($"GameController.Get() called and game id=[{game.GameID}]");
        //System.IO.File.AppendAllText("./obj/api.log", "GameController.Get() called\n");
		//for(int i=0;i<roundsToSimulate;i++)	game.Tick(game.Map);
        //return Ok(new {a="hhh",b="ccc"});
        Response.Headers.AccessControlAllowOrigin="*";
        Response.Headers.AccessControlAllowHeaders="*";
        // Swagger does not like two methods with same route even if HTTP method is different
        if(Response.HttpContext.Request.Method==HttpMethod.Options.ToString()) return Ok(); 
        //return Ok( new { mapObjects=game.Map.mapObjects, mapActionObjects=game.Map.mapObjects.Where(mo=>mo is (MapActionObject<mo.GetType()>)).Cast<MapActionObject<Type>>() });
        return Ok( new { mapObjects=game.Map.mapObjects, mapActionObjects=game.Map.mapObjects.Cast<Object>(), xTiles=game.Map.xTiles, yTiles=game.Map.yTiles });
        //return Ok( game.Map.mapObjects.Cast<Object>() );
    }
}
