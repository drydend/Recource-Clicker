using LevelMap;

namespace SaveSystem
{
    public interface IMapDataSaver
    {
        void SaveMap(Map map);
        Map LoadMap();
    }
}