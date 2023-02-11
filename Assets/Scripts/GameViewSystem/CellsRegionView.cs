using LevelMap;
using System.Collections.Generic;

namespace LevelViewSystem
{
    public class CellsRegionView
    {
        private List<CellView> _view;

        public CellsRegionView()
        {
            _view = new List<CellView>();
        }

        public CellsRegionView(List<CellView> cellViews)
        {
            _view = cellViews;
        }

        public void AddCellView(CellView cellView)
        {
            _view.Add(cellView);
        }
    }
}
