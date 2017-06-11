using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;
    public bool Managed;

    void Start()
    {
        Managed = false;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (target.position != agent.destination)
            {
                agent.destination = target.position;
            }
    }
}
