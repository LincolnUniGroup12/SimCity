using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(tileMap))]
public class TileMapMouse : MonoBehaviour {

    tileMap _tileMap;
    public GameObject House1;
    public GameObject House2;
    public GameObject House3;
    bool select1;
    bool select2;
    bool select3;

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
            if (select1)
            {
                Instantiate(House1, new Vector3(currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
            }
            else if (select2)
            {
                Instantiate(House2, new Vector3(currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
            }
            else if (select3)

            {
                Instantiate(House3, new Vector3(currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
            }


        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            select1 = true;
            select2 = false;
            select3 = false;
            Debug.Log("House 1 selected");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            select1 = false;
            select2 = true;
            select3 = false;
            Debug.Log("House 2 selected");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            select1 = false;
            select2 = false;
            select3 = true;
            Debug.Log("House 3 selected");

        }
    }
}
