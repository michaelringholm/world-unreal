using System.Text.Json;
using com.opusmagus.wu.bl;
using com.opusmagus.wu.simple;

Console.WriteLine("console started...");
//var game = new GameBO();
//game.StartNewGame();
var game=new Game();
game.StartGame();
var json=JsonSerializer.Serialize(game.Map.mapObjects);
Console.WriteLine($"json={json}");
Console.WriteLine("console ended.");