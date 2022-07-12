using com.opusmagus.wu.dtl;

namespace com.opusmagus.wu.bl;

public class MapBO {
    private MapDTO mapDTO;

    public MapBO() {
        mapDTO=new MapDTO();
    }

    public MapDTO CreateMap()
    {
        return new MapDTO();
    }
}