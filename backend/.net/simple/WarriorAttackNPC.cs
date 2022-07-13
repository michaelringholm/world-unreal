namespace com.opusmagus.wu.simple;
public class WarriorAttackNPC : GameAction<Warrior>
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"attacking npc...");
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        bias.biasFactor = 0;
    }
}