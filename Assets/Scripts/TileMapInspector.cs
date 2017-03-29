using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(tileMap))]
public class TileMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        if (GUILayout.Button("Regenerate"))
        {
            tileMap tileMap = (tileMap)target;
            tileMap.BuildMesh();
        } 
    }
}
