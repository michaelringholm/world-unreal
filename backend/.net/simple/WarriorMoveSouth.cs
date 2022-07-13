namespace com.opusmagus.wu.simple;
public class WarriorMoveSouth : WarriorMove
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"moving south...");
        // Need to handle map boundaries
        if(warrior.pos.y==0) Console.WriteLine($"out of bounds, doing nothing...");
        else warrior.pos.y-=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.S);
    }
}