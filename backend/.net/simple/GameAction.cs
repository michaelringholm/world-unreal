namespace com.opusmagus.wu.simple;
public abstract class GameAction<T>
{
    public Bias bias { get; set; } = new Bias(1);
    public abstract void Act(T actionable);
    public abstract void AdjustBias(Map map, T actionableObject);
}