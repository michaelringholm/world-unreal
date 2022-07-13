namespace com.opusmagus.wu.simple;
public class WarriorMoveNorth : WarriorMove
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"moving north...");
        // Need to handle map boundaries
        if(warrior.pos.y==map.yTiles-1) Console.WriteLine($"out of bounds, doing nothing...");
        else warrior.pos.y+=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.N);
    }
}