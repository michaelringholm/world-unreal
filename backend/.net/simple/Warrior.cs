namespace com.opusmagus.wu.simple;
public class Warrior : NPC<Warrior>, IActionable
{    
    public Warrior()
    {
        baseHp=20;
        hp=20;
        attackPower=2;
        AddAction(new WarriorMoveAnywhere());
        AddAction(new WarriorMoveNorth());
        AddAction(new WarriorMoveSouth());
        AddAction(new WarriorMoveEast());
        AddAction(new WarriorMoveWest());
        AddAction(new WarriorAttackNPC());
        AddAction(new WarriorAttackBuilding());
    }

	private void AdjustBiases(Map map)
    {
        foreach (var action in actions)
        {
            action.AdjustBias(map, this);
        }
    }

	override public void HandleTick(Map map)
    {
        AdjustBiases(map);
        var action = Decide();
        action.Act(map, this);
    }
}