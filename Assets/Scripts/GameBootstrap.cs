using LevelMap;
using LevelViewSystem;
using SaveSystem;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField]
        private CellViewFabric _cellViewFabric;
        [SerializeField]
        private Transform _cellsViewParent;

        private MapSaver _mapSaver;
        private Map _map;
        private CellsVisualizer _cellsVisualizer;

        private void Awake()
        {
            _mapSaver = new MapSaver(new EditorJsonMapDataSaver());
            _map = _mapSaver.LoadMap();
            _map.InitializeMap();
            _cellsVisualizer = new CellsVisualizer(_map, _cellViewFabric, _cellsViewParent);
        }

        private void Start()
        {
            _cellsVisualizer.VisualizeMap();
        }
    }
}
