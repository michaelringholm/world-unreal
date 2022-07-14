namespace com.opusmagus.wu.simple;
public abstract class MapActionObject<T>:MapObject
{
    public List<GameAction<T>> actions;
    public int hp { get; set; }
    public int attackPower { get; set; }
    public IEnumerable<dynamic> enemyObjectsInRange { get; internal set; }
}