namespace com.opusmagus.wu.simple;
public class WarriorMoveWest : WarriorMove
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"moving west...");
        if(warrior.pos.x==0) Console.WriteLine($"out of bounds, doing nothing...");
        else warrior.pos.x-=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.W);
    }
}