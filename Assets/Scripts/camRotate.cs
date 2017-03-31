using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotate : MonoBehaviour {


	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -90.0f;
	public float maxY = 90.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	public float rotationY;
	public float rotationX;




	void Start() {
		rotationX = transform.rotation.eulerAngles.y;
		rotationY = -transform.rotation.eulerAngles.x;
	}
	

	void Update () {
		if (Input.GetMouseButton(1))
		{

			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

		}
	}
}
