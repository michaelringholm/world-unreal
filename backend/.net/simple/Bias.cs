namespace com.opusmagus.wu.simple;
public class Bias
{
    public int biasFactor;
    public int currentBiasRangeStart = 0;

    public Bias(int biasFactor)
    {
        this.biasFactor = biasFactor;
    }
    public int currentBiasRangeEnd
    {
        get { return currentBiasRangeStart + biasFactor; }
    }
}