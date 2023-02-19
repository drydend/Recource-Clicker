using Resources;
using System;
using UnityEngine;

namespace BuildingSystem
{
    [Serializable]
    public class BuildingDataCostPair
    {
        [SerializeField]
        private BuildingData _building;

        [SerializeField]
        private ResourcesList _cost;

        public BuildingData BuildingData => _building;
        public ResourcesList Cost => _cost;
    }
}
