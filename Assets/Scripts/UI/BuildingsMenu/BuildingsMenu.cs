using BuildingSystem;
using Infrastructure;
using Resources;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingsMenu
{
    public class BuildingsMenu : MonoBehaviour
    {
        [SerializeField]
        private BuildingMenuSlot _slotPrefab;
        [SerializeField]
        private RectTransform _slotsParent;

        private List<BuildingData> _avaibleBuildings;
        private BuildingMenuSlotFabric _slotFabric;

        private List<BuildingMenuSlot> _buildingMenuSlots = new List<BuildingMenuSlot>();

        public void Initialize(List<BuildingData> avaibleBuildings, BuildingMenuSlotFabric slotFabric)
        {
            _avaibleBuildings = avaibleBuildings;
            _slotFabric = slotFabric;
        }

        public void CreateSlots()
        {
            foreach (var buildingData in _avaibleBuildings)
            {
                var buildingSlot = _slotFabric.CreateSlot(_slotPrefab, buildingData, _slotsParent);
                _buildingMenuSlots.Add(buildingSlot);
            }
        }

        public void AddBuilding(BuildingData data)
        {
            _avaibleBuildings.Add(data);

            var buildingSlot = _slotFabric.CreateSlot(_slotPrefab, data, _slotsParent);
            _buildingMenuSlots.Add(buildingSlot);
        }
    }
}
