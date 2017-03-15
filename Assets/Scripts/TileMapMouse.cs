using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

    TileMap _tileMap;

    Vector3 currentTileCoord;

    public Transform selectionCube;
    void Start()
    {
        _tileMap = GetComponent<TileMap>();
    }
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if ( GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x / _tileMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / _tileMap.tileSize);
           // Debug.Log("Tile: " + x + "," + z);

            currentTileCoord.x = x;
            currentTileCoord.z = z;

            selectionCube.transform.position = currentTileCoord;
        }
        else
        {
          
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
        }
	}
}
