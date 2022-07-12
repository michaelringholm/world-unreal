using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class NPCBO
{
    private List<NPCDTO> npcs;

    public enum ActionTypeEnum { Move=0, AttackOpponent=1, AttackCastle=2 };
    public ActionBO TakeAction(NPCDTO npc, MapDTO map)
    {
        lookAround(npc, map);
        var rand = new Random();
        int actionIndex=rand.Next()%3;
        var action=(ActionTypeEnum)actionIndex;
        Console.WriteLine($"action=[{action}]");
        switch(action) {
            case ActionTypeEnum.Move: return new MoveActionBO();
            case ActionTypeEnum.AttackOpponent: return new AttackOpponentActionBO();
            case ActionTypeEnum.AttackCastle: return new AttackCastleActionBO();
            default: return new ConfusedActionBO();
        }
    }

    public List<NPCDTO> SpawnNPCs(MapDTO map)
    {
        npcs = new List<NPCDTO>();
        npcs.Add(new NPCDTO{ Faction=FactionDTO.FactionEnum.Human, HP=20, AttackPower=2, CurrentLocation = new MapLocationDTO{XPos=5,YPos=5} });
        npcs.Add(new NPCDTO{ Faction=FactionDTO.FactionEnum.Orc, HP=20, AttackPower=2, CurrentLocation = new MapLocationDTO{XPos=30,YPos=7} });
        return npcs;
    }

    public void Tick(MapDTO map)
    {
        foreach(var npc in npcs) {
            TakeAction(npc, map);            
        }
    }

    private void lookAround(NPCDTO npc, MapDTO map)
    {
        
    }
}
