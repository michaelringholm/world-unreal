using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class GameBO {
    private MapBO? mapBO;
    private NPCBO? npcBO;
    private BuildingBO buildingBO;
    private MapDTO map;
    private List<NPCDTO> npcs;
    private List<BuildingDTO> buildings;

    public GameBO() {
        mapBO = new MapBO();
        npcBO = new NPCBO();
        buildingBO = new BuildingBO();
        npcs=new List<NPCDTO>();
        buildings=new List<BuildingDTO>();
    }

    public void StartNewGame() {
        map=mapBO.CreateMap();
        npcBO.SpawnNPCs(map);
        buildingBO.SpawnBuildings(map);

        for(var i=0;i<10; i++)
            Tick();        
    }

    private void Tick()
    {
        npcBO.Tick(map);
        buildingBO.Tick(map);                    
    }
}