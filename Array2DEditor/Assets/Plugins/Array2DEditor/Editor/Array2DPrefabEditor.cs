using UnityEditor;
using Unity ;
using UnityEngine;

namespace Array2DEditor
{
    [CustomEditor(typeof(Array2DPrefab))]
    public class Array2DPrefabEditor : Array2DEditor
    {
        protected override int CellWidth { get { return 96; } }
        protected override int CellHeight { get { return 16; } }

        protected override void SetValue(SerializedProperty cell, int i, int j)
        {
            GameObject[,] previousCells = (target as Array2DPrefab).GetCells();

            cell.objectReferenceValue  = default(GameObject);

            if (i < gridSize.vector2IntValue.y && j < gridSize.vector2IntValue.x)
            {
                cell.objectReferenceValue = previousCells[i, j];
            }
        }
    }
}