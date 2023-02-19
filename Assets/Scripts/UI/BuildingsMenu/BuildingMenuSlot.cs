using BuildingSystem;
using Infrastructure;
using Resources;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BuildingMenuSlot : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        
        private BuildingData _data;
        private ResourcesList _buildingCost;
        private GameModesController _gameModesController;
        private ResourceStorage _resourceStorage;

        public void Initialize(BuildingData data, GameModesController gameModesController,
            ResourcesList buildingCost, ResourceStorage resourceStorage)
        {
            _button.onClick.AddListener(OnBuildButtonPressed);

            _data = data;
            _buildingCost = buildingCost;
            _gameModesController = gameModesController;
            _resourceStorage = resourceStorage;
        }

        public void OnBuildButtonPressed()
        {
            if (_resourceStorage.HaveEnoughResources(_buildingCost, out ResourcesList requaredResources))
            {
                return;
            }

            _gameModesController.EnterBuilderMode(_data);
        }
    }
}
