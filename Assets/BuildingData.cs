using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour {
    public int buildingHealth;
    bool living;
	// Use this for initialization
	void Start () {
        buildingHealth = 100;  //WILL CHANGE, JUST NEEDED FOR TESTING
        living = true;
	}

    // Update is called once per frame
    void Update() {
        if (buildingHealth <= 0 && living)        //if the building's health is zero or less,
        {
            print("building Destroyed");
            enemyTargetManager.updateMainTargets(this.gameObject);      //set the probabilty of this target being given to an enemy to zero, and readjust the probabilities, and update any enemies that have this as a target
            living = false;
        }
	}
}
