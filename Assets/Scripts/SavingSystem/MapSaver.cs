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

        public CellsMap LoadMap()
        {
            return _dataSaver.LoadBaseCellsMap();
        }
    }
}
