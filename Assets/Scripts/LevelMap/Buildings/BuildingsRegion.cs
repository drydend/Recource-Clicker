using BuildingSystem;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace LevelMap
{
    [Serializable]
    public class BuildingsRegion
    {
        [NonSerialized]
        private Dictionary<MapPoint, BuildingData> _buildingData;

        public List<BuildingData> Buildings { get; private set; }
        public int BaseCellsRegionId;

        public BuildingData this[MapPoint cellPosition]
        {
            get
            {
                if (_buildingData.ContainsKey(cellPosition))
                {
                    return _buildingData[cellPosition];
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public BuildingsRegion(int baseCellsRegionId, List<BuildingData> buildings)
        {
            BaseCellsRegionId = baseCellsRegionId;
            Buildings = buildings;
            _buildingData = new Dictionary<MapPoint, BuildingData>();
        }

        public BuildingsRegion(int baseCellsRegionId)
        {
            BaseCellsRegionId = baseCellsRegionId;
            _buildingData = new Dictionary<MapPoint, BuildingData>();
            Buildings = new List<BuildingData>();
        }

        public BuildingsRegion()
        {
            _buildingData = new Dictionary<MapPoint, BuildingData>();
            Buildings = new List<BuildingData>();
        }

        public List<BuildingData> GetBuildings()
        {
            return Buildings;
        }

        public bool ContainsBuildingAt(MapPoint mapPoint)
        {
            return _buildingData.ContainsKey(mapPoint);
        }

        public void DeleteBuildingAt(MapPoint position)
        {
            if (!_buildingData.ContainsKey(position))
            {
                return;
            }

            _buildingData.Remove(position);
        }

        public void SetBuildings(BuildingData buildingData)
        {
            if (_buildingData.ContainsKey(buildingData.Position))
            {
                var buildingIndex = Buildings.FindIndex(building => building.Position == buildingData.Position);
                Buildings.RemoveAt(buildingIndex);
                _buildingData.Remove(buildingData.Position);
            }

            Buildings.Add(buildingData);
            _buildingData.Add(buildingData.Position, buildingData);
        }

        public void InitializeDictionary()
        {
            _buildingData.Clear();

            foreach (var buildingData in Buildings)
            {
                _buildingData.Add(buildingData.Position, buildingData);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BuildingsRegion region &&
                   BaseCellsRegionId == region.BaseCellsRegionId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BaseCellsRegionId);
        }
    }
}
