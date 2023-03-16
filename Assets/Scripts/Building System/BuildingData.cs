using System;
using UnityEngine;

namespace BuildingSystem
{
    [Serializable]
    public class BuildingData
    {
        [HideInInspector]
        public MapPoint Position;

        [SerializeField]
        private bool _generateId;
        
        [SerializeField] 
        private BuildingType _type;
        [SerializeField]
        private int _variation;
        [SerializeField]
        private int _id;

        public BuildingType Type => _type;
        public int Id => _id;
        public int Variation => _variation;

        public BuildingData(MapPoint position, BuildingType type = BuildingType.None, int id = 0, int variation = 0,
            bool generateId = true)
        {
            _type = type;
            _id = id;
            _variation = variation;
            Position = position;
            _generateId = generateId;

            if (_generateId)
            {
                _id = GetHashCode();
            }
        }

        public bool HasTheTypeAs(BuildingData buildingData)
        {
            return Type == buildingData.Type &&
                   Id == buildingData.Id &&
                   Variation == buildingData.Variation;
        }

        public override string ToString()
        {
            return $"Type: {_type} , Id: {_id} , Variation: {_variation} , Map Position {Position}";
        }

        internal BuildingData GetCopy()
        {
            return new BuildingData(Position, Type, _id, _variation, false);
        }
    }
}
