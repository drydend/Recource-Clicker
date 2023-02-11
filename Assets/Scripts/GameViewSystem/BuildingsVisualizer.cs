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

        private Map _map;
        private BuildingViewFabric _buildingViewFabric;
        private Transform _buildingViewParent;
        public BuildingsVisualizer(Map map, BuildingViewFabric buildingViewFabric, Transform buildingViewParent)
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
            var buildingsView = new List<BuildingView>();

            foreach (var cell in region.Cells)
            {   
                var buildingViewInstance = VisualizeBuillding(cell.BuildingData, cell);
                buildingsView.Add(buildingViewInstance);
            }

            return new CellsRegionBuildingsView(buildingsView);
        }

        private BuildingView VisualizeBuillding(BuildingData data, Cell cell)
        {
            var buildingViewPrefab = _buildingViewFabric.GetView(data);
            
            var position = cell.CellPosition.ToVector();
            var viewInstance = Object.Instantiate(buildingViewPrefab, _buildingViewParent);
            viewInstance.transform.localPosition = position;
            
            return viewInstance;
        }
    }
}
