namespace com.opusmagus.wu.dtl;
public class NPCDTO
{
    public enum FactionEnum { Orc, Human }
    public FactionEnum Faction { get; set; }
    public int HP { get; set; }
    public int AttackPower { get; set; }
    public MapLocationDTO CurrentLocation { get; set; }
}
