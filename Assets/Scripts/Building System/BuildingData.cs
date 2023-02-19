using System;
using UnityEngine;

namespace BuildingSystem
{
    [Serializable]
    public struct BuildingData
    {
        [SerializeField] 
        private BuildingType _type;
        [SerializeField]
        private int _id;
        [SerializeField]
        private int _variation;

        public BuildingType Type => _type;
        public int Id => _id;
        public int Variation => _variation;

        public BuildingData(BuildingType type = BuildingType.None, int id = 0, int variation = 0)
        {
            _type = type;
            _id = id;
            _variation = variation;
        }

        public static bool operator ==(BuildingData a, BuildingData b)
        {
            return a.Type == b.Type && a.Id == b.Id;
        }

        public static bool operator !=(BuildingData a, BuildingData b)
        {
            return a.Type != b.Type || a.Id != b.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is BuildingData data &&
                   Type == data.Type &&
                   Id == data.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Id);
        }

        public override string ToString()
        {
            return $"Type: {_type} , Id: {_id} , Variation: {_variation}";
        }
    }
}
