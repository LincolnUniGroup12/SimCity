using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citizenviewer : MonoBehaviour {
    private int Police = 10;
    private int Hospital = 10;
    private int School = 10;
    private float Average;


    void Start () {
        Average = Police + Hospital + School;
        if (Average >= 30)
        {
            Debug.Log("happy");
        }
        else if (Average < 20 && Average > 10) {
            Debug.Log("normal");
        }
        else
        {
            Debug.Log("upset");
        }
    }
	
	
	void Update () {
		
	}
}
