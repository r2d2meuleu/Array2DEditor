using UnityEngine;
using Array2DEditor;

public class TestPrefabArray : MonoBehaviour
{

    [SerializeField]
    private Array2DPrefab array2D_Prefab;

	void Start()
    {
        if (array2D_Prefab == null)
        {
            Debug.LogError("Fill in all the fields in order to start this example.");
            return;
        }

        GameObject[,] cells = array2D_Prefab.GetCells();

        GameObject piece = new GameObject("Piece");

        for(int i = 0; i < array2D_Prefab.GridSize.x; i++)
        {
            for(int j = 0; j < array2D_Prefab.GridSize.y; j++)
            {
                if (cells[i, j])
                {
                    GameObject prefabGO = Instantiate(cells[i, j], new Vector3(i, 0, j), Quaternion.identity, piece.transform);
                    prefabGO.name = "(" + i + ", " + j + ")";
                }
            }
        }
	}
}