namespace com.opusmagus.wu.simple;
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