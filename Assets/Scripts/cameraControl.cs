using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    private Vector3 lastMousePos = Vector3.zero; bool right_mouse_down = false; private Vector3 direction = Vector3.zero;
    public float x, y;
                                                      //Remember public variables can only be changed in editor: changing them here wont change anything
    public float camSpeed = 0.2f, rotate_speed = 0.2f;                    //Speed for camera movements
	                                                 //Feel free to add a second variable for zooming speed if needed

	void Update () {
        RotateCamera();
        mov_camera();
		ScaleCamera ();

	}
    void mov_camera()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 tempForward = transform.forward;
            tempForward.y = 0f;
            tempForward.Normalize();
            direction += tempForward;     //W key moves camera forward
            direction.Normalize();
            transform.position += direction * Time.deltaTime * camSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 tempForward = transform.forward;
            tempForward.y = 0f;
            tempForward.Normalize();
            direction += -tempForward;         //S key moves camera backward
            direction.Normalize();
            transform.position += direction * Time.deltaTime * camSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += -transform.right;//A key moves camera left
            direction.Normalize();
            transform.position += direction * Time.deltaTime * camSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right; ;        //D key moves camera right
            direction.Normalize();
            transform.position += direction * Time.deltaTime * camSpeed;
        }
    }
    private void RotateCamera()
    {

        if (Input.GetMouseButtonDown(1))
        {
            lastMousePos = Input.mousePosition;
            right_mouse_down = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            right_mouse_down = false;
        }
        if (right_mouse_down)
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 mouseOffset = currentMousePos - lastMousePos;
           
                transform.RotateAround(Vector3.zero, Vector3.up, mouseOffset.x * Time.deltaTime * rotate_speed);
                transform.RotateAround(Vector3.zero, transform.right, -mouseOffset.y * Time.deltaTime * rotate_speed);
              
            lastMousePos = currentMousePos;
        }
    }
	private void ScaleCamera () {
		//	获取鼠标滚轮滚动
		float mouseScr = Input.GetAxis ("Mouse ScrollWheel");
		//	如果滚动了滚轮
		if (mouseScr != 0f) {
			//	获取滚动方向
			mouseScr = mouseScr > 0 ? 1f : -1f;

			//	移动摄像机
			transform.position += transform.forward * Time.deltaTime * camSpeed * mouseScr;

		}
	}

}
