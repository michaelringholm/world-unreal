namespace com.opusmagus.wu.simple;
public class Castle : Building<Castle>
{
    public Castle()
    {
        proximity=3;
        AddAction(new CastleAttackNPC());
    }

	override public void HandleTick(Map map)
    {
        AdjustBiases(map);
        var action = base.Decide();
        action.Act(this);
    }

	protected void AdjustBiases(Map map)
    {
        foreach (var action in actions)
        {
            action.AdjustBias(map, this);
        }
    }
}