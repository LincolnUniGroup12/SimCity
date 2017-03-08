using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfeatures : MonoBehaviour {


	public GameObject play;
	public GameObject playtext;
	public GameObject date;
	public GameObject ff;
	public GameObject slow;

	public float dayFloat;
	public int day = 1;
	public int month = 1;
	public int year = 2000;

	public bool paused = true;



	void Start () {
		Time.timeScale = 0.33f;
	}
	

	void FixedUpdate () {
		dayFloat += Time.deltaTime;
		day = (int)dayFloat;

		date.GetComponent<Text> ().text = "Date: " + day + "/" + month + "/" + year;

		if (month == 2) {
			if (day == 28) {
				month++;
				day = 0;
			}
		}
		if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 | month == 12) {
			if (day == 31) {
				month++;
				day = 0;
			}
		}
		if (month == 4 || month == 6 || month == 9 || month == 11) {
			if (day == 30) {
				month++;
				day = 0;
			}
		}
	}


	public void Playpause() {
		if (paused) {

			Time.timeScale = 0.33f;
			paused = false;
			playtext.GetComponent<Text> ().text = "Pause";
		} else {

			Time.timeScale = 0f;
			paused = true;
			playtext.GetComponent<Text> ().text = "Play";
		}
	}

	public void ff1() {

	}
}
