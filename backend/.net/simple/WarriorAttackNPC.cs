namespace com.opusmagus.wu.simple;
public class WarriorAttackNPC : GameAction<Warrior>
{
    override public void Act(Map map, Warrior warrior)
    {
        Console.WriteLine($"attacking npc...");
        var weakestEnemy=warrior.enemyObjectsInRange.MinBy(eo=>eo.hp);
        if(weakestEnemy!=null) weakestEnemy.hp-=warrior.attackPower;
        //var weakestEnemyWarrior=warrior.enemyObjectsInRange.Where(eo=>eo is Warrior).Cast<Warrior>().MinBy(w=>w.hp);
        //var weakestEnemyCastle=warrior.enemyObjectsInRange.Where(eo=>eo is Castle).Cast<Castle>().MinBy(w=>w.hp);
    }

    override public void AdjustBias(Map map, Warrior warrior)
    {
        var enemyMapObjsInRange=map.mapObjects.Where(mo=>mo.GetType().GetInterfaces().Contains(typeof(IActionable))).Where(mo=>mo.faction!=warrior.faction).Where(mo=>(Distance.Calc(warrior.pos.x, mo.pos.x, warrior.pos.y, mo.pos.y)-mo.proximity)<=0);
        if(enemyMapObjsInRange!=null && enemyMapObjsInRange.Count()>0) {
            bias.biasFactor=1000;
            warrior.enemyObjectsInRange=enemyMapObjsInRange;
        }
        else bias.biasFactor=0;
    }
}