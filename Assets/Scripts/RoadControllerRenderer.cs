using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadControllerRenderer : MonoBehaviour {
	int[,] Roads = new int[100, 100];
	public float xStart, zStart, yStart;
	public float Spacing;
	public Texture SS, SC, SR, MS, MC, MR, LS, LC, LR;
	public Material BaseMaterial;
	Mesh mesh = null;
	Material[] mats = new Material[9];
	void Start () {
		for(int z = 0; z < Roads.Length/100; z++) {
			for (int x = 0; x < Roads.Length/100; x++)
			{
				Roads[x, z] = 0;
			}
		}
		mesh = new Mesh ();
		mesh.vertices = new Vector3[] {
			new Vector3 (-Spacing / 2, 0, -Spacing / 2),
			new Vector3 (Spacing / 2, 0, -Spacing / 2),
			new Vector3 (-Spacing / 2, 0, Spacing / 2),
			new Vector3 (Spacing / 2, 0, Spacing / 2)
		};
		mesh.uv = new Vector2[] {
			new Vector2 (0,0),
			new Vector2 (1,0),
			new Vector2 (0,1),
			new Vector2 (1,1)
		};
		mesh.triangles = new int[] {
			0,2,1,
			2,3,1
		};
		mesh.RecalculateNormals ();
		mats = new Material[]{
			matGen (SS),
			matGen (SC),
			matGen (SR),
			matGen (MS),
			matGen (MC),
			matGen (MR),
			matGen (LS),
			matGen (LC),
			matGen (LR)
		};
	}
	Material matGen(Texture text){
		Material mat = new Material (BaseMaterial);
		mat.mainTexture = text;
		//print (mat.mainTexture);
		return mat;
	}
	// Update is called once per frame
	void Update () {
		for (int z = 0; z < Roads.Length/100; z++) {
			for (int x = 0; x < Roads.Length/100; x++) {
				if (Roads [x, z] != _NONE) {

					Vector3 position = new Vector3 (xStart + Spacing * x, 0, zStart + Spacing * z);
					int index = 0;
					switch (Roads [x, z]) {
					case _SMALL:
						break;
					case _MEDIUM:
						index += 3;
						break;
					case _LARGE:
						index += 6;
						break;
					}
					int road = getRoadDir (x, z);
					Quaternion quat = Quaternion.identity;
					switch (road) {
					case 0:
					case 1:
						index += 0;
						break;
					case 2:
					case 3:
					case 4:
					case 5:
						index += 1;
						break;
					case 6:
						index += 2;
						break;
					}
					switch (road) {
					case 0:
						quat = Quaternion.AngleAxis (90, Vector3.up);
						break;
					case 1:
						break;
					case 2:
						quat = Quaternion.AngleAxis (0, Vector3.up);
						break;
					case 3://
						quat = Quaternion.AngleAxis (90, Vector3.up);
						break;
					case 4:
						quat = Quaternion.AngleAxis (-90, Vector3.up);
						break;
					case 5://
						quat = Quaternion.AngleAxis (180, Vector3.up);
						break;
					}
					Graphics.DrawMesh (mesh, position, quat, mats[index], 0, null, 0, null, false, true, true);
				}
			}
		}
	}
	int getRoadDir(int x, int z){
		if ((getPos (x - 1, z) || getPos (x + 1, z)) && !getPos (x, z - 1) && !getPos (x, z + 1)) {
			return 0;
		}
		if (!getPos (x - 1, z) && !getPos (x + 1, z) && (getPos (x, z - 1) || getPos (x, z + 1))) {
			return 1;
		}
		if (getPos (x - 1, z) && !getPos (x + 1, z) && getPos (x, z - 1) && !getPos (x, z + 1)) {
			return 2;
		}
		if (getPos (x - 1, z) && !getPos (x + 1, z) && !getPos (x, z - 1) && getPos (x, z + 1)) {
			return 3;
		}
		if (!getPos (x - 1, z) && getPos (x + 1, z) && getPos (x, z - 1) && !getPos (x, z + 1)) {
			return 4;
		}
		if (!getPos (x - 1, z) && getPos (x + 1, z) && !getPos (x, z - 1) && getPos (x, z + 1)) {
			return 5;
		}
		/*if ((getPos (x - 1, z)||getPos (x + 1, z))&&(!getPos(x,z - 1)||!getPos(x,z+1))) {
			return 0;
		}
		if ((getPos (x, z -1)||getPos (x, z + 1))&&(!getPos(x-1,z)||!getPos(x+1,z))) {
			return 1;
		}*/
		return 6;
	}
	bool getPos(int x, int z){
		if (x < 0 || z < 0 || x >= 100 || z >= 100) {
			return false;
		}
		return Roads [x, z]!=0;
	}
	public void setRoad(int Size, int x, int z){
		Roads [x, z] = Size;
	}
	public int getRoad(int x, int z){
		return Roads [x, z];
	}
	public const int _NONE = 0;
	public const int _SMALL = 1;
	public const int _MEDIUM = 2;
	public const int _LARGE = 3;
}
