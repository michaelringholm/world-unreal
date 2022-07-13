using System;
using System.Collections.Generic;
using System.Linq;

namespace com.opusmagus.wu.simple;

public class Game
{
    public Map Map { get; set; }
    public void StartGame()
    {
        Console.WriteLine("started...");
        Map=BuildMap();
		var roundsToSimulate = 1;
		for(int i=0;i<roundsToSimulate;i++)	Tick(Map);
        Console.WriteLine("ended.");
    }

    public void Tick(Map map)
    {
        map.HandleTick();
    }

    public Map BuildMap()
    {
        var map = new Map(50, 50);
        var orc = new Warrior { pos = new Position { x = 8, y = 5 }, label = "Orc", faction = Faction.FactionEnum.Orc };
        var orcCastle = new Castle { pos = new Position { x = 2, y = 3 }, label = "Orc Castle", faction = Faction.FactionEnum.Orc };
        //var human = new Warrior { pos = new Position { x = 30, y = 7 }, label = "Human", faction = Faction.FactionEnum.Human };
        var human = new Warrior { pos = new Position { x = 20, y = 7 }, label = "Human", faction = Faction.FactionEnum.Human };
        var human2 = new Warrior { pos = new Position { x = 5, y = 7 }, label = "Human 2", faction = Faction.FactionEnum.Human };
        var human3 = new Warrior { pos = new Position { x = 4, y = 5 }, label = "Human 3", faction = Faction.FactionEnum.Human };
        var humanCastle = new Castle { pos = new Position { x = 36, y = 9 }, label = "Human Castle", faction = Faction.FactionEnum.Human };
        AddToMap(map, orc);
        AddToMap(map, orcCastle);
        AddToMap(map, human);
        AddToMap(map, human2);
        AddToMap(map, human3);
        AddToMap(map, humanCastle);
        return map;
    }

    public void AddToMap(Map map, MapObject mapObject)
    {
        map.Add(mapObject); // Create Map.map
        Console.WriteLine($"Added {mapObject.label} to map at x={mapObject.pos.x} and y={mapObject.pos.y}");
    }
}



public class WarriorMoveNorth : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving north...");
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.N);
    }
}

public class WarriorMoveSouth : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving south...");
    }

        override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.S);
    }
}

public class WarriorMoveEast : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving east...");
    }

        override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.E);
    }
}

public class WarriorMoveWest : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving west...");
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.W);
    }
}


















