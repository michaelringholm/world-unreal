using System;
using System.Collections.Generic;
using System.Linq;

namespace com.opusmagus.wu.simple;

public class Game
{
    public void StartGame()
    {
        Console.WriteLine("started...");
        var map = BuildMap();
		var roundsToSimulate = 10;
		for(int i=0;i<roundsToSimulate;i++)	Tick(map);
        Console.WriteLine("ended.");
    }

    public void Tick(Map map)
    {
        map.HandleTick();
    }

    public Map BuildMap()
    {
        Map map = new Map(50, 50);
        var orc = new Warrior { pos = new Position { x = 8, y = 5 }, label = "Orc", faction = Faction.FactionEnum.Orc };
        var orcCastle = new Castle { pos = new Position { x = 2, y = 3 }, label = "Orc Castle", faction = Faction.FactionEnum.Orc };
        var human = new Warrior { pos = new Position { x = 30, y = 7 }, label = "Human", faction = Faction.FactionEnum.Human };
        var humanCastle = new Castle { pos = new Position { x = 36, y = 9 }, label = "Human Castle", faction = Faction.FactionEnum.Human };
        AddToMap(map, orc);
        AddToMap(map, orcCastle);
        AddToMap(map, human);
        AddToMap(map, humanCastle);
        return map;
    }

    public void AddToMap(Map map, MapObject mapObject)
    {
        map.Add(mapObject); // Create Map.map
        Console.WriteLine($"Added {mapObject.label} to map at x={mapObject.pos.x} and y={mapObject.pos.y}");
    }
}

public class Bias
{
    public int biasFactor;
    public int currentBiasRangeStart = 0;

    public Bias(int biasFactor)
    {
        this.biasFactor = biasFactor;
    }
    public int currentBiasRangeEnd
    {
        get { return currentBiasRangeStart + biasFactor; }
    }
}

public abstract class GameAction<T>
{
    public Bias bias = new Bias(1);
    public abstract void Act(T actionable);
    public abstract void AdjustBias(Map map, T actionableObject);
}

public class IdleAction : GameAction<Object>
{
    override public void Act(Object obj)
    {
        Console.WriteLine($"moving west...");
    }

    override public void AdjustBias(Map map, Object actionableObject)
    {
    }
}

public class WarriorAttackNPC : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"attacking npc...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public class WarriorAttackBuilding : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving west...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public class WarriorMoveAnywhere : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving west...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public class WarriorMoveNorth : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving north...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
		//warrior.pos.x;
		//map.mapObjects.Where(mo=>mo.pos.x);
        bias.biasFactor = 100;
    }
}

public class WarriorMoveSouth : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving south...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public class WarriorMoveEast : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving east...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public class WarriorMoveWest : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving west...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 100;
    }
}

public abstract class Faction
{
    public enum FactionEnum { Neutral, Human, Orc };
}

public class Warrior : NPC<Warrior>
{
    public Warrior()
    {
        AddAction(new WarriorMoveAnywhere());
        AddAction(new WarriorMoveNorth());
        AddAction(new WarriorMoveSouth());
        AddAction(new WarriorMoveEast());
        AddAction(new WarriorMoveWest());
        AddAction(new WarriorAttackNPC());
        AddAction(new WarriorAttackBuilding());
    }

	private void AdjustBiases(Map map)
    {
        foreach (var action in actions)
        {
            action.AdjustBias(map, this);
        }
    }

	override public void HandleTick(Map map)
    {
        AdjustBiases(map);
        var action = Decide();
        action.Act(this);
    }
}

public abstract class NPC<T> : MapObject
{
    public List<GameAction<T>> actions;

    public NPC()
    {
        actions = new List<GameAction<T>>();
        //actions.Add(new IdleAction());
    }

    public void AddAction(GameAction<T> action)
    {
        actions.Add(action);
    }

    protected GameAction<T> Decide()
    {
        var biasFactorSum = actions.Sum(a => a.bias.biasFactor);
        var actionCount = actions.Count;
        Console.WriteLine($"sum of all biases for [{label}] are=[{biasFactorSum}]");
        Console.WriteLine($"number of actions for [{label}] are=[{actions.Count}]");
        var currentBiasRangeStart = 0;
        foreach (var action in actions)
        {
            action.bias.currentBiasRangeStart = currentBiasRangeStart;
            currentBiasRangeStart += action.bias.biasFactor;
            Console.WriteLine($"[{action.GetType().Name}] bias range=[{action.bias.currentBiasRangeStart},{action.bias.currentBiasRangeEnd}]");
        }
        var rand = new Random();
        var biasRangeIndexChoice = rand.Next(0, biasFactorSum);
        Console.WriteLine($"biasRangeIndexChoice=[{biasRangeIndexChoice}]");
        var seletedAction = actions.Where(a => a.bias.currentBiasRangeStart <= biasRangeIndexChoice && a.bias.currentBiasRangeEnd >= biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.currentBiasRangeStart<=biasRangeIndexChoice).Where(a=>a.currentBiasRangeEnd>=1).FirstOrDefault(); //.Where(a=>a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault(); // && a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.bias.currentBiasRangeStart>=1).Count();
        Console.WriteLine($"seletedAction=[{seletedAction}]");
        return actions.First(); // Use random with biases
    }
}

public class CastleAttackNPC : GameAction<Castle>
{
    override public void Act(Castle obj)
    {
    }

    override public void AdjustBias(Map map, Castle obj)
    {
    }
}

public class Castle : Building<Castle>
{
    public Castle()
    {
        AddAction(new CastleAttackNPC());
    }

	override public void HandleTick(Map map)
    {
        AdjustBiases(map);
        var action = base.Decide();
        action.Act(this);
    }

	protected void AdjustBiases(Map map)
    {
        foreach (var action in actions)
        {
            action.AdjustBias(map, this);
        }
    }
}

public abstract class Building<T> : MapObject
{
    public List<GameAction<T>> actions;

    public Building()
    {
        actions = new List<GameAction<T>>();
        //actions.Add(new IdleAction());
    }

    public void AddAction(GameAction<T> action)
    {
        actions.Add(action);
    }

    protected GameAction<T> Decide()
    {
        var biasFactorSum = actions.Sum(a => a.bias.biasFactor);
        var actionCount = actions.Count;
        Console.WriteLine($"sum of all biases for [{label}] are=[{biasFactorSum}]");
        Console.WriteLine($"number of actions for [{label}] are=[{actions.Count}]");
        var currentBiasRangeStart = 0;
        foreach (var action in actions)
        {
            action.bias.currentBiasRangeStart = currentBiasRangeStart;
            currentBiasRangeStart += action.bias.biasFactor;
            Console.WriteLine($"[{action.GetType().Name}] bias range=[{action.bias.currentBiasRangeStart},{action.bias.currentBiasRangeEnd}]");
        }
        var rand = new Random();
        var biasRangeIndexChoice = rand.Next(0, biasFactorSum);
        Console.WriteLine($"biasRangeIndexChoice=[{biasRangeIndexChoice}]");
        var seletedAction = actions.Where(a => a.bias.currentBiasRangeStart <= biasRangeIndexChoice && a.bias.currentBiasRangeEnd >= biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.currentBiasRangeStart<=biasRangeIndexChoice).Where(a=>a.currentBiasRangeEnd>=1).FirstOrDefault(); //.Where(a=>a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault(); // && a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.bias.currentBiasRangeStart>=1).Count();
        Console.WriteLine($"seletedAction=[{seletedAction}]");
        return actions.First(); // Use random with biases
    }
}

public abstract class MapObject
{
    public Position pos;
    public string label;
    public int proximity;
    public Faction.FactionEnum faction;
    public abstract void HandleTick(Map map);
}

public class Position
{
    public int x;
    public int y;
}

public class Map
{
    public MapObject[,] map;
    public List<MapObject> mapObjects;

    public Map(int xTiles, int yTiles)
    {
        map = new MapObject[xTiles, yTiles];
        mapObjects = new List<MapObject>();
    }

    public void Add(MapObject mapObject)
    {
        map[mapObject.pos.x, mapObject.pos.y] = mapObject;
        mapObjects.Add(mapObject);
    }

    public void HandleTick()
    {
        foreach (var mapObject in mapObjects)
            mapObject.HandleTick(this);
    }
}

