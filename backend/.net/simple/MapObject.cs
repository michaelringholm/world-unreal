namespace com.opusmagus.wu.simple;
public abstract class MapObject
{
    public Position pos;
    public string label;
    public int proximity;
    public Faction.FactionEnum faction;
    public abstract void HandleTick(Map map);
}