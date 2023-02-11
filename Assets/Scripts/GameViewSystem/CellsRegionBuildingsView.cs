using System.Collections.Generic;

namespace LevelViewSystem
{
    public class CellsRegionBuildingsView
    {
        private List<BuildingView> _view;

        public CellsRegionBuildingsView()
        {
            _view = new List<BuildingView>();
        }

        public CellsRegionBuildingsView(List<BuildingView> buildingView)
        {
            _view = buildingView;
        }

        public void AddCellView(BuildingView buildingView)
        {
            _view.Add(buildingView);
        }
    }
}