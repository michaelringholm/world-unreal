using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl
{
    public class BuildingBO
    {
        public BuildingBO()
        {
        }

        public List<BuildingDTO> SpawnBuildings(MapDTO map)
        {
            var buildings = new List<BuildingDTO>();
            buildings.Add(new BuildingDTO{ Faction=FactionDTO.FactionEnum.Human, HP=500, AttackPower=5, CurrentLocation = new MapLocationDTO{XPos=2,YPos=5} });
            buildings.Add(new BuildingDTO{ Faction=FactionDTO.FactionEnum.Orc, HP=500, AttackPower=5, CurrentLocation = new MapLocationDTO{XPos=33,YPos=7} });
            return buildings;
        }

        internal void Tick(MapDTO map)
        {
            throw new NotImplementedException();
        }
    }
}