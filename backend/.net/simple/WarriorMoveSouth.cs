namespace com.opusmagus.wu.simple;
public class WarriorMoveSouth : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving south...");
        // Need to handle map boundaries
        warrior.pos.y-=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.S);
    }
}