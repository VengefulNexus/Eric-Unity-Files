using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemyTargetManager : MonoBehaviour {
    public static LinkedList<GameObject> managedEnemies = new LinkedList<GameObject>();     //create a linked list to hold all enemies on the map
    public static float[] currentProbabilities = { 0.5f, 0.25f, 0.125f, 0.125f }; // Player Base, Factory defending dam, barracks, quarry; the probability split of how targets are given out
    public static GameObject[] originalTargets = new GameObject[4];        //an array to hold the gameobjects for the main level targets (quarry, base, factory, etc)
    public static float[] newProbabilities = currentProbabilities;          //a temporary array to hold interum probability values after destruction of a target
    public static LinkedList<GameObject> enemyTargets = new LinkedList<GameObject>();   //a linked list to hold all possible targets the enemies can attack (base, quarry, player towers, satellite uplinks, etc)

    void Start () {
        updateEnemyTargets();   //add all gameobjects with tag "building" to the linked list enemyTargets so enemies will be able to search and use this.attack()
        originalTargets[0] = GameObject.Find("PlayerBase"); //set all originaltarget values to the gameobjects of each main building
        originalTargets[1] = GameObject.Find("Optional(1)");
        originalTargets[2] = GameObject.Find("Optional(2)");
        originalTargets[3] = GameObject.Find("Optional(3)");
        getNewEnemies();        //adds all enemies to managedEnemies and gives them a target to move to ******NEEDS TO BE CALLED IN UPDATE OR SOMETHING THAT RUNS WHEN AN ENEMY IS SPAWNED******
    }

    public static void updateEnemyTargets(GameObject destroyedBuilding = null)  //Call this on the destruction of a player created building (or anything the enemies will attack but was not generated at start)
    {
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Building")) //iterates through each building in the game
        {
            if (!enemyTargets.Contains(target))     //if the building is not in the enemyTargets linked list,
            {
                enemyTargets.AddLast(target);       //it adds it to the list
            }
        }
        if (destroyedBuilding != null)          //if the method was passed a gameobject,
        {
            enemyTargets.Remove(destroyedBuilding); //it will remove that destroyed gameobject from the list enemyTargets
        }
    }

    public static Transform getNewTarget()      //method to chose and return the transform object of a main target to move to; if the target was destroyed, the 0 probability will make it impossible to set that as the target
    {
        Transform target;                           //placeholder target variable
        float value = UnityEngine.Random.Range(0.0f, 1.0f); //picks a random float between 0 and 1 to determine target
        if (value < currentProbabilities[0] && value > 0.0f)    //if within 0 and the first cutoff <0.5>, target is playerBase
        {
            target = originalTargets[0].GetComponent<Transform>();  //set target variable to the transform of the playerBase
        } else if (value < (currentProbabilities[0] + currentProbabilities[1])) //if not and the value is under the sum of the first two cutoffs <0.5+0.25> (with a p=0.25),
        {
            target = originalTargets[1].GetComponent<Transform>();      //target is set to transform of second target
        } else if (value < (currentProbabilities[0] + currentProbabilities[1] + currentProbabilities[2]))   //if not and under sum of first 3 cutoffs <0.875> (p = 0.125) then.
        {
            target = originalTargets[2].GetComponent<Transform>();      //target set to transform of third target
        } else
        {
            target = originalTargets[3].GetComponent<Transform>();      //otherwise target is set to transform of fourth target (p = 0.125)
        }
        return target;          //returns transform of the selected building
    }

    public static void updateMainTargets(GameObject destroyedTarget)     //Call this upon the destruction of any main target (i.e. base/quarry/factory/etc)
    {
        int targetIndex = Array.IndexOf(originalTargets, destroyedTarget);      //finds index of the destroyed target to determine corresponding index of the gameobject's probability used in getNewTarget()
        float destroyedProbability = currentProbabilities[targetIndex];         //saves the probability of the destroyed target since the arrays are in the same order
        float newTotal = 0.0f;                                                  //create a variable to hold a total new probability for scaling new probabilities correctly
        for (int i = 0; i < originalTargets.Length; i++)                        //iterates though each probability (i = 0,1,2,3)
        {
            if (i != targetIndex)                               //if the current probability index is not the corresponding index of the destroyed target,
            {
                newProbabilities[i] *= destroyedProbability;    //multiply the current (temp probability that was copied in on startup) probabilty of that building by the destroyed building's
                newTotal += newProbabilities[i];                //add that probability to the total probability
            }
        }

        for (int i = 0; i < originalTargets.Length; i++)        //iterate through the same list now that all newProbabilities and total are set (i=0,1,2,3)
        {
            if (i != targetIndex)                               //if this index is not the index of the destroyed target,
            {
                currentProbabilities[i] = newProbabilities[i] / newTotal;   //set the final probability to the newProbability scaled by the division of the total probability
            } else
            {
                currentProbabilities[i] = 0.0f;             //if the index is the index of the destroyed target, set the probability to 0
            }
        }
        newProbabilities = currentProbabilities;        //copies the currentprobabilities into newprobabilities for temp use if updateMainTargets is called again

        foreach (GameObject Enemy in managedEnemies)        //iterate through each enemy this script manages
        {
            if (Enemy.GetComponent<enemyMovement>().target == destroyedTarget.GetComponent<Transform>())  //if the target of this enemy is the destroyed target,
            {
                Enemy.GetComponent<enemyMovement>().target = getNewTarget();        //assigns a new target to the enemy
            }
        }

    }

    public static void getNewEnemies()          //called to update linked list of enemies this script manages
    {
        foreach(GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))     //iterates through each gameobject with the tag "Enemy"
        {
            if (!Enemy.GetComponent<enemyData>().Managed)                   //if the enemy is not managed
            {
                managedEnemies.AddLast(Enemy);                          //add the enemy to the linked list
                Enemy.GetComponent<enemyData>().Managed = true;         //set the managed property of the enemy to true
                Enemy.GetComponent<enemyMovement>().target = getNewTarget();    //assign a target to the enemy
            }
        }
    }

    public static void removeEnemy(GameObject Enemy)            //call this script upon the destruction of an enemy
    {
        managedEnemies.Remove(Enemy);                   //remove this enemy from the linked list of enemies this script manages
    }
}
