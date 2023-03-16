using BuildingSystem;
using LevelMap;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewSystem
{
    public class BuildingsVisualizer
    {
        Dictionary<CellsRegion, CellsRegionBuildingsView> _cellsRegionBuildingsViews = 
            new Dictionary<CellsRegion, CellsRegionBuildingsView>();

        private CellsMap _map;
        private BuildingViewFactory _buildingViewFabric;
        private Transform _buildingViewParent;
        public BuildingsVisualizer(CellsMap map, BuildingViewFactory buildingViewFabric, Transform buildingViewParent)
        {
            _map = map;
            _buildingViewFabric = buildingViewFabric;
            _buildingViewParent = buildingViewParent;
        }

        public void VisualizeBuildings()
        {
            foreach (var region in _map.Regions)
            {
                if (!region.IsUnlocked)
                {
                    continue;
                }

                var cellsRegionBuildingsView = VisualizeRegionBuilding(region);
                _cellsRegionBuildingsViews.Add(region, cellsRegionBuildingsView);
            }
        }

        private CellsRegionBuildingsView VisualizeRegionBuilding(CellsRegion region)
        {
            throw new System.NotImplementedException();
        }

        private BuildingView VisualizeBuillding(BuildingData data)
        {
            var buildingViewPrefab = _buildingViewFabric.GetView(data);
            
            var position = data.Position.ToVector();
            var viewInstance = Object.Instantiate(buildingViewPrefab, _buildingViewParent);
            viewInstance.transform.localPosition = position;
            
            return viewInstance;
        }
    }
}
