using LevelMap;
using LevelViewSystem;

namespace BuildingSystem
{
    public class BuildingsBuilder
    {
        private Map _map;
        private BuildingsVisualizer _buildingsVisualizer;

        public BuildingsBuilder(Map map, BuildingsVisualizer buildingsVisualizer)
        {
            _map = map;
            _buildingsVisualizer = buildingsVisualizer;
        }

        public bool TryPlaceBuilding(BuildingData data, MapPoint position)
        {
            return false;
        }

        public bool TryDeleteBuildigAt(MapPoint position)
        {
            return false;
        }

    }
}
