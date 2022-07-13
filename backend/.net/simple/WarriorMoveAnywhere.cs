namespace com.opusmagus.wu.simple;

public class WarriorMoveAnywhere : WarriorMove
{
    override public void Act(Map map, Warrior warrior)
    {        
        Console.WriteLine($"moving anywhere...");
        var rand=new Random();
        var moveDirectionIndex=rand.Next(0,4);
        var direction=(Direction.DirectionEnum)moveDirectionIndex;
        Console.WriteLine($"move anywhere resulting in trying to move towards {direction.ToString()}...");
        // Need to handle map boundaries
        if(direction==Direction.DirectionEnum.E) {
            if(warrior.pos.x==map.xTiles-1) Console.WriteLine($"out of bounds, doing nothing...");
            else warrior.pos.x+=1;
        }
        if(direction==Direction.DirectionEnum.W) {
            if(warrior.pos.x==0) Console.WriteLine($"out of bounds, doing nothing...");
            else warrior.pos.x-=1;
        }
        if(direction==Direction.DirectionEnum.N) {
            if(warrior.pos.y==map.yTiles-1) Console.WriteLine($"out of bounds, doing nothing...");
            else warrior.pos.y+=1;
        }
        if(direction==Direction.DirectionEnum.S) {
            if(warrior.pos.y==0) Console.WriteLine($"out of bounds, doing nothing...");
            else warrior.pos.y-=1;
        }
    }

    override public void AdjustBias(Map map, Warrior warrior) {
        var minAdjustedDistance=map.mapObjects.Where(mo=>mo.faction!=warrior.faction).Min(mo=>(Distance.Calc(warrior.pos.x, mo.pos.x, warrior.pos.y, mo.pos.y)-mo.proximity));
        if(minAdjustedDistance>1) bias.biasFactor=1000; else bias.biasFactor=0;        
    }
}