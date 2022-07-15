using System.Text.Json;
using com.opusmagus.wu.bl;
using com.opusmagus.wu.simple;

Console.WriteLine("console started...");
//var game = new GameBO();
//game.StartNewGame();
var game=new Game();
game.StartGame();

(new Thread(() => {            
    while(true) {
        Thread.Sleep(1000);
        try {
        var json=JsonSerializer.Serialize(game.Map.mapObjects);
        var response=new { mapObjects=game.Map.mapObjects, mapActionObjects=game.Map.mapObjects.Cast<Object>() };
        Console.WriteLine($"json={JsonSerializer.Serialize(response)}");
        }
        catch(Exception ex) {
            var ex2=ex;
        }
    }
})).Start();
Console.WriteLine("console ended.");