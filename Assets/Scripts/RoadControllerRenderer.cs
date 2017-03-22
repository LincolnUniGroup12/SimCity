using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadControllerRenderer : MonoBehaviour {
	int[,] Roads = new int[100, 100];
	int xStart, yStart;
	double Spacing;
	int z;
	Mesh[] CrossRoads = new Mesh[4];
	Mesh[] StraightRoads = new Mesh[4];
	Mesh[] EndRoads = new Mesh[4];
	// Use this for initialization
	void Start () {
		for(int y = 0; y < Roads.Length; y++) {
			for (int x = 0; x < Roads.Length; x++)
			{
				Roads[x, y] = 0;
			}
		}
		for (int i = 0; i < 4; i++) {
			//Cross Roads
			double offset = 0.1+0.1*i;
			Vector3[] verts = new Vector3[12];
			verts [0] = new Vector3 (-offset, -1, 0)*Spacing;
			verts [1] = new Vector3 (offset, -1, 0)*Spacing;
			verts [2] = new Vector3 (-1, -offset, 0)*Spacing;
			verts [3] = new Vector3 (-offset, -offset, 0)*Spacing;
			verts [4] = new Vector3 (offset, -offset, 0)*Spacing;
			verts [5] = new Vector3 (1, -offset, 0)*Spacing;
			verts [6] = new Vector3 (-1, offset, 0)*Spacing;
			verts [7] = new Vector3 (-offset, offset, 0)*Spacing;
			verts [8] = new Vector3 (offset, offset, 0)*Spacing;
			verts [9] = new Vector3 (1, offset, 0)*Spacing;
			verts [10] = new Vector3 (-offset, 1, 0)*Spacing;
			verts [11] = new Vector3 (offset, 1, 0)*Spacing;

		}
	}
	int[] tri(int i, int j, int k){
		return new int[]{ i, j, k };
	}
	// Update is called once per frame
	void Update () {
		for (int y = 0; y < Roads.Length; y++) {
			for (int x = 0; x < Roads.Length; x++) {
				if (Roads [x, y] != _NONE) {
					double WMult = (Roads [x, y] / 3) * 2;

					Vector3 position = new Vector3 (xStart + Spacing * x, yStart + Spacing * y);
					Mesh mesh = new Mesh ();
					Graphics.drawMesh (mesh, position);
				}
			}
		}
	}
	public const int _NONE = 0;
	public const int _SMALL = 1;
	public const int _MEDIUM = 2;
	public const int _LARGE = 3;
}
