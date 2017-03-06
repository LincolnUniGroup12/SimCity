using UnityEngine;
using System.Collections;
//	摄像机移动方向
public class camera : MonoBehaviour 
{
	public float x, y;
	public GameObject camera_control;	//	当前目标
	public float move_speed,rotate_speed,scale_speed;	//	camera parameter
	private int wide, heigh; //monitor size
	private bool click_right_mouse = false;	

	void initialization () 
	{
		wide = Screen.width;
		heigh = Screen.height;
	}

	void Update () 
	{
		RotateCamera ();
		ScaleCamera ();
		if (!click_right_mouse) 
		{
			MoveCamera ();
		}
	}
	private void RotateCamera () 
	{
		Quaternion rotation_euler;
		if (Input.GetMouseButtonDown(1))
		{
			x += Input.GetAxis ("Mouse X") * rotate_speed * Time.deltaTime;
			y -= Input.GetAxis ("Mouse Y") * rotate_speed * Time.deltaTime;
			rotation_euler = Quaternion.Euler (y, x, 0);
			transform.rotation = rotation_euler;
		}
	}
		
	private void ScaleCamera () 
	{
		float mouseScr = Input.GetAxis ("Mouse ScrollWheel");
		if (mouseScr != 0f) 
		{
			mouseScr = mouseScr > 0 ? 1f : -1f;
			transform.position += transform.forward * Time.deltaTime * scale_speed * mouseScr;
		}
	}
	//	移动摄像机
	private void MoveCamera () 
	{  
		if (Input.GetMouseButtonDown(0))
		{
		float position_x, position_y;
		position_x = -Input.GetAxis("Mouse X")*move_speed;
		position_y = -Input.GetAxis("Mouse Y")*move_speed;
			transform.Translate(position_x,position_y,0);
		}
	}
}