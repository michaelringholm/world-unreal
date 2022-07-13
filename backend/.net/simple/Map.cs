namespace com.opusmagus.wu.simple;
public class Map
{
    public MapObject[,] map;
    public List<MapObject> mapObjects;

    public Map(int xTiles, int yTiles)
    {
        map = new MapObject[xTiles, yTiles];
        mapObjects = new List<MapObject>();
    }

    public void Add(MapObject mapObject)
    {
        map[mapObject.pos.x, mapObject.pos.y] = mapObject;
        mapObjects.Add(mapObject);
    }

    public void HandleTick()
    {
        foreach (var mapObject in mapObjects)
            mapObject.HandleTick(this);
    }
}