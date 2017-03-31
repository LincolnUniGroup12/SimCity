using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(tileMap))]
public class TileMapMouse : MonoBehaviour {

    tileMap _tileMap;
    public GameObject Cube;

    Vector3 currentTileCoord;

    public Transform selectionCube;
    void Start()
    {
        _tileMap = GetComponent<tileMap>();
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
            Debug.Log("Tile: " + currentTileCoord.x + "," + currentTileCoord.z);
            Instantiate(Cube, new Vector3(currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
        }
	}
}
