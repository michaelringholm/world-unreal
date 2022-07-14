namespace com.opusmagus.wu.simple;
public class CastleAttackNPC : GameAction<Castle>
{
    override public void Act(Map map, Castle castle)
    {
        if(castle.enemyObjectsInRange!=null && castle.enemyObjectsInRange.Count()>0) {
        Console.WriteLine($"attacking npc...");
        var weakestEnemy=castle.enemyObjectsInRange.MinBy(eo=>eo.hp);
        if(weakestEnemy!=null) weakestEnemy.hp-=castle.attackPower;
        }
    }

    override public void AdjustBias(Map map, Castle castle)
    {
        var enemyMapObjsInRange=map.mapObjects.Where(mo=>mo.GetType().GetInterfaces().Contains(typeof(IActionable))).Where(mo=>mo.faction!=castle.faction).Where(mo=>(Distance.Calc(castle.pos.x, mo.pos.x, castle.pos.y, mo.pos.y)-mo.proximity)<=0);
        map.mapObjects.OfType<Object>();
        if(enemyMapObjsInRange!=null && enemyMapObjsInRange.Count()>0) {
            bias.biasFactor=1000;
            castle.enemyObjectsInRange=enemyMapObjsInRange;
        }
        else bias.biasFactor=0;
    }
}