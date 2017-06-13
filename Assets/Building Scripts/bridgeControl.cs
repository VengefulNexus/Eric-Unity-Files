using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bridgeControl : MonoBehaviour {
    public Animator bridgeAnimator;
    public NavMeshObstacle AvoidCube;

    public bool bridgeStatus;

    public MeshRenderer bottomButton; //for init

    // Use this for initialization
    void Start () {

        bridgeAnimator.SetBool("BridgeUp", false);

        bottomButton.material.color = new Color(0.0f, 0.7843f, 0.0f);
    }

    // Update is called once per frame
    void Update() {

     }

    public void setBridgeUp()
    {
        bridgeAnimator.SetBool("BridgeUp", true);
        bridgeStatus = true;
    }

    public void setBridgeDown()
    {
        bridgeAnimator.SetBool("BridgeUp", false);
        bridgeStatus = false;

    }

    public void updateAvoidCube()
    {
        AvoidCube.enabled = bridgeStatus;
    }
}
