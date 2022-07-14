namespace com.opusmagus.wu.simple;
public class Castle : Building<Castle>, IActionable
{
    public Castle()
    {
        proximity=3;
        hp=500;
        attackPower=4;
        AddAction(new CastleAttackNPC());
    }

	override public void HandleTick(Map map)
    {
        AdjustBiases(map);
        var action = base.Decide();
        action.Act(map, this);
    }

	protected void AdjustBiases(Map map)
    {
        foreach (var action in actions)
        {
            action.AdjustBias(map, this);
        }
    }
}