using BuildingSystem;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewSystem
{
    [CreateAssetMenu(menuName = "Building Fabric")]
    public class BuildingViewFabric : ScriptableObject
    {
        [SerializeField]
        private List<BuildingDataViewPair> _buildingDataViewPairs;

        public BuildingView GetView(BuildingData data)
        {
            var view = _buildingDataViewPairs.Find(pair => pair.Data.Type == data.Type && pair.Data.Id == data.Id
            && pair.Data.Variation == data.Variation).View;

            if(view == null)
            {
                throw new System.Exception($"Building view of type: {data.Type}," +
                    $" variation: {data.Variation}, id: {data.Id} is not defined in fabric");
            }

            return view;
        }
    }
}
