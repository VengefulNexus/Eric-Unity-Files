using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyData : MonoBehaviour {

    public bool Managed;
    public int enemySpeed;
    public int enemyTurnSpeed;
    public int enemyAcceleration;

    public int enemyAttack;
    public int enemyHealth;
    public int enemyAttackDistance;
    public int enemyAttackSpeed;
    public float attackDelay;

    // Use this for initialization
    void Start () {
        Managed = false;            //initalize this enemy as not managed so the enemyManager script can pick it up
    }

	void attack(GameObject Building)        //called when the enemy is within attacking distance of a building it can attack
    {
        Building.GetComponent<BuildingData>().buildingHealth -= enemyAttack;        //WILL BE CHANGED TO INCORPERATE ATTACKDELAY AND OTHER STUFF
    }

	// Update is called once per frame
	void Update () {
        foreach (GameObject Target in enemyTargetManager.enemyTargets) //iterates through each gameobject target the enemy can attack
        {
            if (Vector3.Distance(this.transform.position, Target.transform.position) < enemyAttackDistance)     //if the building is within enemyAttackDistance
            {
                print("attack");
                this.attack(Target);                //call the attack method of this enemy
            }
        }
	}
}
