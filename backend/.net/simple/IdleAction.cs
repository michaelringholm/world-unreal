namespace com.opusmagus.wu.simple;
public class IdleAction : GameAction<Object>
{
    override public void Act(Map map, Object obj)
    {
        Console.WriteLine($"staying idle...");
    }

    override public void AdjustBias(Map map, Object actionableObject)
    {
        bias.biasFactor = 0;
    }
}