using BuildingSystem;
using LevelViewSystem;
using System;
using UnityEngine;

namespace LevelViewSystem
{
    [Serializable]
    public class BuildingDataViewPair
    {
        [SerializeField]
        private BuildingData _data;
        [SerializeField]
        private BuildingView _view;

        public BuildingData Data => _data;
        public BuildingView View => _view;
    }
}
