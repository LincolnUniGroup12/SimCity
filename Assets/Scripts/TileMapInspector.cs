using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileMap))]
public class TileMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        if (GUILayout.Button("Regenerate"))
        {
            TileMap tileMap = (TileMap)target;
            tileMap.BuildMesh();
        } 
    }
}
