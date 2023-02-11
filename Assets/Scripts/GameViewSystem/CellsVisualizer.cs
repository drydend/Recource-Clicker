using LevelMap;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewSystem
{
    public class CellsVisualizer
    {
        private Dictionary<CellsRegion,CellsRegionView> _cellsRegionViews = new Dictionary<CellsRegion, CellsRegionView>();

        private Map _map;
        private CellViewFabric _cellViewFabric;
        private Transform _cellViewParent;

        public CellsVisualizer(Map map, CellViewFabric cellViewFabric, Transform cellViewParent)
        {
            _map = map;
            _cellViewFabric = cellViewFabric;
            _cellViewParent = cellViewParent;
        }

        public void VisualizeMap()
        {
            foreach (var region in _map.Regions)
            {
                var cellsRegionView = VisualizeRegion(region);
                _cellsRegionViews.Add(region, cellsRegionView);
            }
        }

        private CellsRegionView VisualizeRegion(CellsRegion cellsRegion)
        {
            var cellViews = new List<CellView>();

            foreach (var cell in cellsRegion.Cells)
            {
                CellView cellViewPrefab;

                if (cellsRegion.IsUnlocked)
                {
                    cellViewPrefab = _cellViewFabric.GetUnlockedCellView(cell.Type, cell.CellVariation);
                }
                else
                {
                    cellViewPrefab = _cellViewFabric.GetLockedCellView(_map, cellsRegion ,cell.CellPosition);
                }

                var viewInstance = VisualizeCell(cellViewPrefab, cell);
                cellViews.Add(viewInstance);

            }

            return new CellsRegionView(cellViews);
        }

        private CellView VisualizeCell(CellView viewPrefab , Cell cell)
        {
            var position = cell.CellPosition.ToVector();
            var viewInstance = Object.Instantiate(viewPrefab, _cellViewParent);
            viewInstance.transform.localPosition = position;
            return viewInstance;
        }
    }
}
