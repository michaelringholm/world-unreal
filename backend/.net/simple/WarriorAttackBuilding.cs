namespace com.opusmagus.wu.simple;
public class WarriorAttackBuilding : GameAction<Warrior>
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"attacking building...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 0;
    }
}