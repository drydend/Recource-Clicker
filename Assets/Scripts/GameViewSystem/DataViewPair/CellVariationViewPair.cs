using LevelMap;
using System;
using UnityEngine;

namespace LevelViewSystem
{
    [Serializable]
    public class CellVariationViewPair
    {
        [SerializeField]
        private CellVariation _cellVariation;
        [SerializeField]
        private CellView _cellView;

        public CellVariation CellVariation => _cellVariation;
        public CellView CellView => _cellView;
    }
}
