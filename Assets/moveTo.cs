﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour {
    public Transform goal;
    static NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (goal.position != agent.destination)
        {
            agent.destination = goal.position;
        }
		
	}
}