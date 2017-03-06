using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	                                                 //Remember public variables can only be changed in editor: changing them here wont change anything
	public float camSpeed = 0.2f;                    //Speed for camera movements
	                                                 //Feel free to add a second variable for zooming speed if needed

	void Update () {

		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * camSpeed);      //W key moves camera forward
		}

		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.back * camSpeed);         //S key moves camera backward
		}

		if(Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * camSpeed);         //A key moves camera left
		}

		if(Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * camSpeed);        //D key moves camera right
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)               // Scrolling down zooms out

		{
			transform.Translate(Vector3.up * camSpeed);
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0)               // Scrolling up zooms in
		{
			transform.Translate(Vector3.down * camSpeed);
		}

	}
}
