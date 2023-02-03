using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelMap
{
    [Serializable]
    public class Map
    {
        [NonSerialized]
        private Dictionary<Vector2Int, Cell> _cellsMap;
 
        public List<CellsRegion> Regions { get; private set; }

        public Cell this[Vector2Int cellPosition]
        {
            get
            {
                if (_cellsMap.ContainsKey(cellPosition))
                {
                    return _cellsMap[cellPosition];
                }
                else
                {
                    return null;
                }
            }
        }

        public Map(List<CellsRegion> regions)
        {
            _cellsMap = new Dictionary<Vector2Int, Cell>();

            foreach (var region in regions)
            {
                foreach(var cell in region.Cells)
                {
                    _cellsMap.Add(cell.CellPosition.ToVector2Int(), cell);
                }
            }

            Regions = regions;
        }

        public Map()
        {
            _cellsMap = new Dictionary<Vector2Int, Cell>();
            Regions = new List<CellsRegion>();
        }
    }
}
