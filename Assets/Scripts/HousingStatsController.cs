using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingStatsController : MonoBehaviour {

    // Population factors
    public float Residents;
    public float AbleToWork;
    public float Children;

    // Mood factors
    public float HappinessGain;

    // Accessing the cityStats script
    private cityStats CityStats;

	// Use this for initialization
	void Start ()
    {
        CityStats = FindObjectOfType<cityStats>();

        // Generate a random amount of residents per household
        Residents = Random.Range(2, 6);
        // Generate a random portion of each households residents that are able to work
        AbleToWork = Residents % Random.Range(2, 6);
        /* The amount of children is the amount of residents left over after the amount of people that 
        are able to work are subtracted from the total residents of a household */
        Children = Residents - AbleToWork;

        if (this.gameObject.activeInHierarchy)
        {
            CityStats.population += Residents;
            CityStats.availableJobs += AbleToWork;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
