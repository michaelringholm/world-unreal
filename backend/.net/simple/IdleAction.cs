namespace com.opusmagus.wu.simple;
public class IdleAction<T> : GameAction<T>
{
    override public void Act(Map map, T obj)
    {
        Console.WriteLine($"staying idle...");
    }

    override public void AdjustBias(Map map, T actionableObject)
    {
        bias.biasFactor = 1;
    }
}