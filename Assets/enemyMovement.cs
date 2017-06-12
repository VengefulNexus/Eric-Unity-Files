using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {
    public Transform target;
    public NavMeshAgent agent;
    public enemyData DataHolder;

    void Start()
    {
        agent.acceleration = DataHolder.enemyAcceleration;      //sets the NavMeshAgent's acceleration, speed, and angular speed based on the values in the enemy's enemyData
        agent.speed = DataHolder.enemySpeed;
        agent.angularSpeed = DataHolder.enemyTurnSpeed;
    }

    void Update()
    { 

    }

    public void updateNavAgent()
    {
        agent.destination = target.position;    //set the NavMeshAgent's target to the position of the enemy's target
    }
}
