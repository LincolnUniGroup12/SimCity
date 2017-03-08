using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BuildMesh ();
	}
	

	void BuildMesh() {
		Vector3[] vertices = new Vector3[4];
		int[] triangles = new int[2 * 3];
		Vector3[] normals = new Vector3[4];
		Vector2[] uv = new Vector2[4];

		vertices [0] = new Vector3 (0, 0, 0);
		vertices [1] = new Vector3 (100, 0, 0);
		vertices [2] = new Vector3 (0, 0, -100);
		vertices [3] = new Vector3 (100, 0, -100);

		triangles [0] = 0;
		triangles [1] = 3;
		triangles [2] = 2;

		triangles [3] = 0;
		triangles [4] = 1;
		triangles [5] = 3;

		normals [0] = Vector3.up;
		normals [1] = Vector3.up;
		normals [2] = Vector3.up;
		normals [3] = Vector3.up;

		uv [0] = new Vector2 (0,1);
		uv [1] = new Vector2 (1,1);
		uv [2] = new Vector2 (0,0);
		uv [3] = new Vector2 (1,0);

		Mesh mesh = new Mesh ();

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;

		MeshFilter meshfilter = GetComponent<MeshFilter> ();
		MeshRenderer meshrenderer = GetComponent<MeshRenderer> ();
		MeshCollider meshcollider = GetComponent<MeshCollider> ();

		meshfilter.mesh = mesh;


	}


}
