using UnityEngine;
using Unity;

namespace Array2DEditor
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Array2DTilemapToPrefab", menuName = "Array2D/Tilemap2Prefab")]
    public class Array2DTilemapToPrefabs : Array2D<GameObject>
    {
        [SerializeField]
        public Texture2D spriteSheet;

        [SerializeField]
        CellRowPrefab[] cells = new CellRowPrefab[Consts.defaultGridSize];

        [SerializeField]
        public int tileWidth ;

        protected override CellRow<GameObject> GetCellRow(int idx)
        {
            return cells[idx];
        }
        
    }
}