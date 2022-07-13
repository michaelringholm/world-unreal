namespace com.opusmagus.wu.simple;

public class WarriorMoveAnywhere : WarriorMove
{
    override public void Act(Warrior warrior)
    {
        Console.WriteLine($"moving anywhere...");
        var rand=new Random();
        var moveDirectionIndex=rand.Next(0,3);
        var direction=(Direction.DirectionEnum)moveDirectionIndex;
        // Need to handle map boundaries
        if(direction==Direction.DirectionEnum.E) warrior.pos.x+=1;
        if(direction==Direction.DirectionEnum.W) warrior.pos.x-=1;
        if(direction==Direction.DirectionEnum.N) warrior.pos.y+=1;
        if(direction==Direction.DirectionEnum.S) warrior.pos.y-=1;
        else warrior.pos.x+=1;
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        var minAdjustedDistance=map.mapObjects.Where(mo=>mo.faction!=warrior.faction).Min(mo=>(Distance.Calc(warrior.pos.x, mo.pos.x, warrior.pos.y, mo.pos.y)-mo.proximity));
        if(minAdjustedDistance>1) bias.biasFactor=1000; else bias.biasFactor=0;        
    }
}