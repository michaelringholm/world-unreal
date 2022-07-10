using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class GameBO {
    private MapBO mapBO;
    private NPCBO npcBO;
    private List<NPCDTO> npcs;

    public void StartNewGame() {
        mapBO = new MapBO();
        npcBO = new NPCBO();
        npcs = mapBO.SpawnNPCs();

        for(var i=0;i<10; i++)
            Tick();        
    }

    private void Tick()
    {
        foreach(var npc in npcs) {
            var action=npcBO.TakeAction(npc);
            action.Execute(npc);            
            Console.WriteLine($"took action=[{action}]");
        }
    }
}