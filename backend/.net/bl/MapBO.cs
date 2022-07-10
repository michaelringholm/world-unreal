using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class MapBO {
    public void Move() {

    }

    public List<NPCDTO> SpawnNPCs()
    {
        var npcs = new List<NPCDTO>();
        npcs.Add(new NPCDTO{ Faction=NPCDTO.FactionEnum.Human, HP=20, AttackPower=2, CurrentLocation = new MapLocationDTO{XPos=5,YPos=5} });
        npcs.Add(new NPCDTO{ Faction=NPCDTO.FactionEnum.Orc, HP=20, AttackPower=2, CurrentLocation = new MapLocationDTO{XPos=30,YPos=7} });
        return npcs;
    }
}