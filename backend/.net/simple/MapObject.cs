namespace com.opusmagus.wu.simple;
public abstract class MapObject
{
    public Position pos { get; set; }
    public string label { get; set; }
    public int proximity { get; set; }
    public Faction.FactionEnum faction;
    public abstract void HandleTick(Map map);
}