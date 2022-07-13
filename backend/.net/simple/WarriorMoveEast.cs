namespace com.opusmagus.wu.simple;
public class WarriorMoveEast : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving east...");
        // Need to handle map boundaries
        warrior.pos.x+=1;
    }

        override public void AdjustBias(Map map, Warrior warrior) {
        base.AdjustMoveBias(map, warrior, Direction.DirectionEnum.E);
    }
}
