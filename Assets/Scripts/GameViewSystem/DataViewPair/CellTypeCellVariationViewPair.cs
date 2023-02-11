using LevelMap;
using LevelViewSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameViewSystem
{
    [Serializable]
    public class CellTypeCellVariationViewPair
    {
        [SerializeField]
        private CellType _cellType;
        [SerializeField]
        private List<CellVariationViewPair> _cellVariationViewPair;

        public CellType Type => _cellType;

        public List<CellVariationViewPair> CellVariationViewPair => _cellVariationViewPair;
    }
}
