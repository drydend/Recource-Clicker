using Resources;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(menuName = "Smeltery recipe", fileName = "Smeltery recipe")]
    public class SmelteryRecipe : ScriptableObject
    {
        [SerializeField]
        private ResourcesList _input;
        [SerializeField]
        private ResourcesList _output;

        public ResourcesList Input => _input;
        public ResourcesList Output => _output;
    }
}