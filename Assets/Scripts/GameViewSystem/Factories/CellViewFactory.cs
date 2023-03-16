using GameViewSystem;
using LevelMap;
using System.Collections.Generic;
using UnityEngine;

namespace LevelViewSystem
{
    [CreateAssetMenu(menuName = "Cell View Factory")]
    public class CellViewFactory : ScriptableObject
    {
        [SerializeField]
        private CellView _lockedCell_TB_Empty;
        [SerializeField]
        private CellView _lockedCell_T_Empty;
        [SerializeField]
        private CellView _lockedCell_B_Empty;
        [SerializeField]
        private CellView _lockedCellPlain;

        [SerializeField]
        private List<CellTypeCellVariationViewPair> _cellDataViewPairs;

        public CellView GetUnlockedCellView(CellType type, CellVariation variation)
        {
            var view = _cellDataViewPairs
                .Find(pair => pair.Type == type)
                .CellVariationViewPair
                .Find(pair => pair.CellVariation == variation)
                .CellView;

            if (view == null)
            {
                throw new System.Exception($"Cell view of type: {type}," +
                   $" variation: {variation} is not defined in fabric");
            }

            return view;
        }


        public CellView GetLockedCellView(CellsMap map, CellsRegion region, MapPoint cellPosition)
        {
            var cellAtTop = map[cellPosition.ToVector2Int() + Vector2Int.up];
            var cellAtBottom = map[cellPosition.ToVector2Int() + Vector2Int.down];

            bool hasCellAtTop = cellAtTop != null && region.Cells.Contains(cellAtTop);
            bool hasCellAtBottom = cellAtBottom != null && region.Cells.Contains(cellAtBottom);

            if (!hasCellAtTop && !hasCellAtBottom)
            {
                return _lockedCell_TB_Empty;
            }
            if (hasCellAtTop && !hasCellAtBottom)
            {
                return _lockedCell_B_Empty;
            }
            if (!hasCellAtTop && hasCellAtBottom)
            {
                return _lockedCell_T_Empty;
            }
            if (hasCellAtTop && hasCellAtBottom)
            {
                return _lockedCellPlain;
            }

            throw new System.Exception("Fabrics does not contains locked cellview");
        }
    }
}
