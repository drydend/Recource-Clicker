using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMap
{
    [Serializable]
    public class CellsRegion
    {   
        public int Id { get; private set; }
        public bool IsUnlocked { get; private set; }
        public string Name { get; private set; }
        public ResourcesList UnlockCost { get; private set; }
        public MapPoint CorePosition { get; private set; }
        public List<Cell> Cells { get; private set;}

        public CellsRegion(List<Cell> cells, int id, bool isUnlocked, string name, ResourcesList unlockCost, MapPoint corePosition)
        {
            Id = id;
            IsUnlocked = isUnlocked;
            Name = name;
            UnlockCost = unlockCost;
            CorePosition = corePosition;
            Cells = cells;
        }

        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }

        public void DeleteCellAt(Vector2Int position)
        {
            var cell = Cells.Find(cell => cell.CellPosition.ToVector2Int() == position);
            
            if(cell == null)
            {
                return;
            }

            Cells.Remove(cell);
        }
    }
}
