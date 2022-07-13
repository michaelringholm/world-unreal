namespace com.opusmagus.wu.simple;
public class WarriorMoveEast : WarriorMove
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"moving east...");
        // Need to handle map boundaries
        if(warrior.pos.x==map.xTiles) Console.WriteLine($"out of bounds, doing nothing...");
        else warrior.pos.x+=1;
    }

        override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.E);
    }
}
