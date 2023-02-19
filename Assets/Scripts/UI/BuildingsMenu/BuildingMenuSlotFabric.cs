using BuildingSystem;
using Infrastructure;
using Resources;
using UI;
using UnityEngine;

namespace UI
{
    public class BuildingMenuSlotFabric
    {
        private GameModesController _gameModesController;
        private BuildingCostFabric _buildingCostFabric;
        private ResourceStorage _resourceStorage;

        public BuildingMenuSlotFabric(GameModesController gameModesController,
            BuildingCostFabric buildingCostFabric, ResourceStorage resourceStorage)
        {
            _gameModesController = gameModesController;
            _buildingCostFabric = buildingCostFabric;
            _resourceStorage = resourceStorage;
        }

        public BuildingMenuSlot CreateSlot(BuildingMenuSlot prefab, BuildingData data, RectTransform parent)
        {
            var slot = Object.Instantiate(prefab, parent);
            var buildingCost = _buildingCostFabric.GetBuildingCost(data);
            slot.Initialize(data, _gameModesController, buildingCost, _resourceStorage);

            return slot;
        }
    }
}
