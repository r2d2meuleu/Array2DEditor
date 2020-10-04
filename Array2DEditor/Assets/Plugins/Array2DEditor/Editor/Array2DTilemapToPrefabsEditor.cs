using UnityEditor;
using Unity ;
using UnityEngine;
using System;


namespace Array2DEditor
{
    [CustomEditor(typeof(Array2DTilemapToPrefabs))]
    public class Array2DTilemapToPrefabsEditor : Array2DEditor
    {
        protected override int CellWidth { get { return 96; } }
        protected override int CellHeight { get { return 16; } }

        private int tileWidth ;
        private string tileText;
        private SerializedProperty spritesheet;

        // protected Texture2D spritesheet ;

        protected override void SetValue(SerializedProperty cell, int i, int j)
        {
            GameObject[,] previousCells = (target as Array2DTilemapToPrefabs).GetCells();

            cell.objectReferenceValue  = default(GameObject);

            if (i < gridSize.vector2IntValue.y && j < gridSize.vector2IntValue.x)
            {
                cell.objectReferenceValue = previousCells[i, j];
            }
        }
        public override void OnInspectorGUI()
        {
            
            // EditorGUILayout.PropertyField(property: spritesheet, includeChildren: true);
            base.OnInspectorGUI();
            spritesheet = serializedObject.FindProperty("spriteSheet");
            EditorGUILayout.PropertyField(spritesheet);
            Texture2D texture = AssetPreview.GetAssetPreview(spritesheet.objectReferenceValue);
            if (texture != null) {
                GUILayout.Label(texture);
                GUILayout.Label(texture.width.ToString() + " pixels wide");
                GUILayout.Label(texture.height.ToString() + " pixels tall");
                tileText = EditorGUILayout.TextField("Tile Width", tileText);
                if (GUILayout.Button("Set Grid Size", EditorStyles.miniButton))
                {
                    tileWidth = Int16.Parse(tileText);
                    int GridWidth = texture.width/tileWidth;
                    int GridHeight = texture.height/tileWidth;
                    newGridSize = gridSize.vector2IntValue;
                    newGridSize.x = GridWidth ;
                    newGridSize.y = GridHeight ;
                    confirmNewGrid() ;
                    lastRect = GUILayoutUtility.GetLastRect();
                    DisplayGrid(lastRect);
                    serializedObject.ApplyModifiedProperties();
                    // InitNewGrid(newGridSize) ;
                }
            }
            // spritesheet = Resources.Load("somePath", typeof(Texture2D)) as Texture2D;
            // GUILayout.Label(spritesheet); //Or draw the texture

        }
    }

}