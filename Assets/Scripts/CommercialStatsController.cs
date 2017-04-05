using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialStatsController : MonoBehaviour {

    public float JobsProvided = 50;
    public float HappinessGain;

    private cityStats CityStats;

	// Use this for initialization
	void Start ()
    {
        CityStats = FindObjectOfType<cityStats>();

        if (this.gameObject.activeInHierarchy)
        {
            CityStats.availableJobs += JobsProvided;
        }
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
  
    }
}
