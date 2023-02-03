using BuildingSystem;
using System;
using UnityEngine;

namespace LevelMap
{
    [Serializable]
    public class Cell
    {
        public CellType Type { get; private set; }
        public CellVariation CellVariation { get; private set; }
        public BuildingData BuildingData { get; private set; }
        public MapPoint CellPosition { get; private set; }
        
        public Cell(CellType type, CellVariation cellVariation, BuildingData buildingData,
            MapPoint cellPosition)
        {
            Type = type;
            CellVariation = cellVariation;
            BuildingData = buildingData;
            CellPosition = cellPosition;
        }

        public void SetTypeAndVariation(CellType cellType, CellVariation cellVariation)
        {
            Type = cellType;
            CellVariation = cellVariation;
        }

        public void SetBuilding(BuildingData data)
        {
            BuildingData = data;
        }
    }
}