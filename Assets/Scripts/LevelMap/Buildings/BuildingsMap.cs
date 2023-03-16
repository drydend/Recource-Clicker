using BuildingSystem;
using System;
using System.Collections.Generic;

namespace LevelMap
{
    [Serializable]
    public class BuildingsMap
    {
        [NonSerialized]
        private Dictionary<MapPoint, BuildingData> _buildings;
        public List<BuildingsRegion> Regions { get; private set; }

        public BuildingsMap(List<BuildingsRegion> regions)
        {
            Regions = regions;
            InitializeDictionary();
        }

        public BuildingsMap()
        {
            Regions = new List<BuildingsRegion>();
        }

        public bool TryGetBuildingAt(MapPoint mapPoint, out BuildingData buildingData)
        {
            if (_buildings.ContainsKey(mapPoint))
            {
                buildingData = _buildings[mapPoint];
                return true;
            }

            buildingData = null;

            return false;
        }

        private void InitializeDictionary()
        {
            _buildings = new Dictionary<MapPoint, BuildingData>();

            foreach (var region in Regions)
            {
                foreach (var buildingData in region.Buildings)
                {
                    _buildings.Add(buildingData.Position, buildingData);
                }
            }
        }
    }
}
