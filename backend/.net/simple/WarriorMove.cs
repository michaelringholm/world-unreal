namespace com.opusmagus.wu.simple;
public abstract class WarriorMove : GameAction<Warrior> {
    public void AdjustMoveBias(Map map, Warrior warrior, Direction.DirectionEnum testedDirection)
    {
		//warrior.pos.x;
		//map.mapObjects.Where(mo=>mo.pos.x);

        var enemyMapObj=map.mapObjects.Where(mo=>mo.faction!=warrior.faction).MinBy(mo=>Distance.Calc(warrior.pos.x, mo.pos.x, warrior.pos.y, mo.pos.y));
        //var enemyMapObjs=map.mapObjects.Where(mo=>mo.faction!=warrior.faction);
        //foreach(var enemyMapObj in enemyMapObjs) {
            //}
        if(enemyMapObj!=null) {
            var distance=Distance.Calc(warrior.pos.x, enemyMapObj.pos.x, warrior.pos.y, enemyMapObj.pos.y);
            var adjustedDistance=distance-enemyMapObj.proximity;
            if(adjustedDistance<0) adjustedDistance=0; // Not sure that this can happen, investigate...
            var direction=Direction.Calc(warrior.pos.x, enemyMapObj.pos.x, warrior.pos.y, enemyMapObj.pos.y, distance);
            Console.WriteLine($"distance between {warrior.label} and  {enemyMapObj.label} are {distance}(adjusted={adjustedDistance}) and most significant direction is {direction.significantHeading.ToString()} following vector x={direction.x},y={direction.y}");
            if(adjustedDistance>1) bias.biasFactor=1; else
            if(direction.significantHeading==testedDirection) bias.biasFactor=1000; else bias.biasFactor=0;
        }
    }
}