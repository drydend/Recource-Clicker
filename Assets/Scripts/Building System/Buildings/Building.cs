using UnityEngine;

namespace BuildingSystem
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private BuildingData _data;


        public BuildingData Data => _data;
    }
}
