using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemyTargetManager : MonoBehaviour {
    public static LinkedList<GameObject> managedEnemies = new LinkedList<GameObject>();
    public static float[] currentProbabilities = { 0.5f, 0.25f, 0.125f, 0.125f }; // Player Base, Factory defending dam, barracks, quarry
    public static Transform[] originalTransforms = new Transform[4];
    public static float[] newProbabilities = currentProbabilities;
    public static GameObject[] enemyTargets;

    void Start () {
        enemyTargets = GameObject.FindGameObjectsWithTag("Building");
        originalTransforms[0] = (GameObject.Find("PlayerBase").GetComponent<Transform>());
        originalTransforms[1] = (GameObject.Find("Optional(1)").GetComponent<Transform>());
        originalTransforms[2] = (GameObject.Find("Optional(2)").GetComponent<Transform>());
        originalTransforms[3] = (GameObject.Find("Optional(3)").GetComponent<Transform>());
        getNewEnemies();
    }
	
	void Update () {
		
	}

    public static Transform getNewTarget()
    {
        Transform target;
        float value = UnityEngine.Random.Range(0.0f, 1.0f);
        if (value < currentProbabilities[0] && value > 0.0f)
        {
            target = originalTransforms[0];
        } else if (value < (currentProbabilities[0] + currentProbabilities[1]))
        {
            target = originalTransforms[1];
        } else if (value < (currentProbabilities[0] + currentProbabilities[1] + currentProbabilities[2]))
        {
            target = originalTransforms[2];
        } else
        {
            target = originalTransforms[3];
        }
        return target;
    }

    public static void updateTargets(Transform destroyedTarget)
    {
        int targetIndex = Array.IndexOf(originalTransforms, destroyedTarget);
        float destroyedProbability = currentProbabilities[targetIndex];
        float newTotal = 0.0f;
        for (int i = 0; i < originalTransforms.Length; i++)
        {
            if (i != targetIndex)
            {
                newProbabilities[i] *= destroyedProbability;
                newTotal += newProbabilities[i];
            }
        }

        for (int i = 0; i < originalTransforms.Length; i++)
        {
            if (i != targetIndex)
            {
                currentProbabilities[i] = newProbabilities[i] / newTotal;
            } else
            {
                currentProbabilities[i] = 0.0f;
            }
        }

        foreach (GameObject Enemy in managedEnemies)
        {
            if (Enemy.GetComponent<enemyMovement>().target == destroyedTarget)
            {
                Enemy.GetComponent<enemyMovement>().target = getNewTarget();
            }
        }

    }

    public static void getNewEnemies()
    {
        foreach(GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!Enemy.GetComponent<enemyMovement>().Managed)
            {
                managedEnemies.AddLast(Enemy);
                Enemy.GetComponent<enemyMovement>().Managed = true;
                Enemy.GetComponent<enemyMovement>().target = getNewTarget();
                //Enemy.GetComponent<enemyMovement>().Begin();
                print("Target Given");
            }
        }
    }
}
