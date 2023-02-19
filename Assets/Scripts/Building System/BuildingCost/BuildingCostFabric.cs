using Resources;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(menuName = "Building cost fabric", fileName = "Building cost fabric")]
    public class BuildingCostFabric : ScriptableObject
    {
        [SerializeField]
        private List<BuildingDataCostPair> _buildingDataCostPairList;

        public ResourcesList GetBuildingCost(BuildingData buildingData)
        {
            var buildingDataCostPair = _buildingDataCostPairList.Find(pair => pair.BuildingData == buildingData);

            if(buildingDataCostPair == null)
            {
                throw new System.Exception($"Cost of building: {buildingData} are not defined");
            }

            return buildingDataCostPair.Cost;
        }

    }
}