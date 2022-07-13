namespace com.opusmagus.wu.simple;
public abstract class MapObject
{
    public Position pos { get; set; }
    public string label { get; set; }
    public int proximity { get; set; }
    public Faction.FactionEnum faction { get; set; }
    public string factionName { get { return faction.ToString(); } }
    public string mapObjectType { get { return this.GetType().Name; } }
    public abstract void HandleTick(Map map);
}