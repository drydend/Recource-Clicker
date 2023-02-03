using LevelMap;

namespace SaveSystem
{
    public class MapSaver
    {
        private IMapDataSaver _dataSaver;

        public MapSaver(IMapDataSaver dataSaver)
        {
            _dataSaver = dataSaver;
        }

        public void SaveMap(Map map)
        {
            _dataSaver.SaveMap(map);
        }

        public Map LoadMap()
        {
            return _dataSaver.LoadMap();
        }
    }
}
