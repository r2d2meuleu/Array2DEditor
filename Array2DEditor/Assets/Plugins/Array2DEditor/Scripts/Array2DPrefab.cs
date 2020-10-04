using UnityEngine;
using Unity;

namespace Array2DEditor
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Array2D_Prefab", menuName = "Array2D/Prefab")]
    public class Array2DPrefab : Array2D<GameObject>
    {
        [SerializeField]
        CellRowPrefab[] cells = new CellRowPrefab[Consts.defaultGridSize];

        protected override CellRow<GameObject> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }

    [System.Serializable]
    public class CellRowPrefab : CellRow<GameObject> { }
}