namespace com.opusmagus.wu.simple;
public abstract class Building<T> : MapObject
{
    public List<GameAction<T>> actions;
    public int hp { get; set; }
    public int attackPower { get; set; }

    public Building()
    {
        actions = new List<GameAction<T>>();
        //actions.Add(new IdleAction());
    }

    public void AddAction(GameAction<T> action)
    {
        actions.Add(action);
    }

    protected GameAction<T> Decide()
    {
        var biasFactorSum = actions.Sum(a => a.bias.biasFactor);
        var actionCount = actions.Count;
        Console.WriteLine($"sum of all biases for [{label}] are=[{biasFactorSum}]");
        Console.WriteLine($"number of actions for [{label}] are=[{actions.Count}]");
        var currentBiasRangeStart = 0;
        foreach (var action in actions)
        {
            action.bias.currentBiasRangeStart = currentBiasRangeStart;
            currentBiasRangeStart += action.bias.biasFactor;
            Console.WriteLine($"[{action.GetType().Name}] bias range=[{action.bias.currentBiasRangeStart},{action.bias.currentBiasRangeEnd}]");
        }
        var rand = new Random();
        var biasRangeIndexChoice = rand.Next(0, biasFactorSum);
        Console.WriteLine($"biasRangeIndexChoice=[{biasRangeIndexChoice}]");
        var seletedAction = actions.Where(a => a.bias.currentBiasRangeStart <= biasRangeIndexChoice && a.bias.currentBiasRangeEnd >= biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.currentBiasRangeStart<=biasRangeIndexChoice).Where(a=>a.currentBiasRangeEnd>=1).FirstOrDefault(); //.Where(a=>a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault(); // && a.currentBiasRangeEnd>=biasRangeIndexChoice).FirstOrDefault();
        //var seletedAction=actions.Where( a=> a.bias.currentBiasRangeStart>=1).Count();
        Console.WriteLine($"seletedAction=[{seletedAction}]");
        if(seletedAction!=null) return seletedAction; else return null;
    }
}