namespace com.opusmagus.wu.simple;
public class CastleAttackNPC : GameAction<Castle>
{
    override public void Act(Castle obj)
    {
    }

    override public void AdjustBias(Map map, Castle obj)
    {
        bias.biasFactor = 0;
    }
}