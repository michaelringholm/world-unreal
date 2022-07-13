namespace com.opusmagus.wu.simple;
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