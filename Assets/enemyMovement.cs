using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;
    public enemyData DataHolder;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       //set the NavMeshAgent component to a variable
        agent.acceleration = DataHolder.enemyAcceleration;      //sets the NavMeshAgent's acceleration, speed, and angular speed based on the values in the enemy's enemyData
        agent.speed = DataHolder.enemySpeed;
        agent.angularSpeed = DataHolder.enemyTurnSpeed;
    }

    void Update()
    { 
        if (target.position != agent.destination)       //if the target the enemy was given is not the same as the NavMeshAgent's target,
            {
                agent.destination = target.position;    //set the NavMeshAgent's target to the position of the enemy's target
            }
    }
}
