namespace com.opusmagus.wu.simple;
public class WarriorMoveWest : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving west...");
        warrior.pos.x-=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.W);
    }
}