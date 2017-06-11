using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour {
    public int buildingHealth;

	// Use this for initialization
	void Start () {
        buildingHealth = 100;  //WILL CHANGE, JUST NEEDED FOR TESTING
	}

    // Update is called once per frame
    void Update() {
        if (buildingHealth <= 0)        //if the building's health is zero or less,
        {
            print("building Destroyed");
            enemyTargetManager.updateMainTargets(this.gameObject);      //set the probabilty of this target being given to an enemy to zero, and readjust the probabilities, and update any enemies that have this as a target
        }
	}
}
