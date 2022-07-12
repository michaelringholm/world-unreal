using static com.opusmagus.wu.dtl.FactionDTO;

namespace com.opusmagus.wu.dtl;
public class NPCDTO
{    
    public FactionEnum Faction { get; set; }
    public int HP { get; set; }
    public int AttackPower { get; set; }
    public MapLocationDTO CurrentLocation { get; set; }
    public int Proximity { get; set; }
    public NPCDTO() { 
        Proximity=2;
    }
}
