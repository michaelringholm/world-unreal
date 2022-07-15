using System.Text.Json.Serialization;

namespace com.opusmagus.wu.simple;
public abstract class MapActionObject<T>:MapObject
{
    [JsonIgnore] public List<GameAction<T>> actions;
    public int baseHp { get; set; }
    public int hp { get; set; }
    public int attackPower { get; set; }    
    [JsonIgnore] public IEnumerable<dynamic> enemyObjectsInRange { get; internal set; }
}