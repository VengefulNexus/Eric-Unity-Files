using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bridgeControl : MonoBehaviour {
    public Animator bridgeAnimator;
    public NavMeshObstacle AvoidCube;

    public bool bridgeUp = false;
    bool state = true;  //only true to immediately update animation and navMeshObstacle enabled

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update() {
        if (bridgeUp != state)
        {
            if (bridgeUp)
            {
                AvoidCube.enabled = true;
            } else
            {
                AvoidCube.enabled = false;
            }
            bridgeAnimator.SetBool("BridgeUp", bridgeUp);
            state = bridgeUp;
        }
	}

}
