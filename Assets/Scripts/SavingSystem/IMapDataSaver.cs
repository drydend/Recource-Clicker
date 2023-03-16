using LevelMap;

namespace SaveSystem
{
    public interface IMapDataSaver
    {
        void SaveBuildingsMap(BuildingsMap buildingsMap);

        CellsMap LoadBaseCellsMap();
        BuildingsMap LoadBaseBuildingsMap();
        BuildingsMap LoadCurrentBuildingsMap();
    }
}