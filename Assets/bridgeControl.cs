using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeControl : MonoBehaviour {
    public Animator bridgeAnimator;

    public bool bridgeUp = false;
    bool state = false;

	// Use this for initialization
	void Start () {
        bridgeAnimator.SetBool("BridgeUp", bridgeUp);
    }

    // Update is called once per frame
    void Update() {
        if (bridgeUp != state)
        {
            bridgeAnimator.SetBool("BridgeUp", bridgeUp);
            state = bridgeUp;
        }
	}

}
