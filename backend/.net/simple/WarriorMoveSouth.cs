namespace com.opusmagus.wu.simple;
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