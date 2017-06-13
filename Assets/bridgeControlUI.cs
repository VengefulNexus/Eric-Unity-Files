using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeControlUI : MonoBehaviour {
    public Transform buildingUIPanelPivot;
    public Transform playerTransform;
    public Transform buildingTransform;
    public GameObject UIPanel;
    public bridgeControl Bridge;

    float xDistance;
    float yDistance;

    float activeDistance = 20.0f;

    float angle = 0.0f;
    bool playerInRange = true;
    
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        UIPanel.transform.localScale = new Vector3(0.001f, 0.005f, 0.001f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(playerTransform.position, buildingTransform.position) < activeDistance && !playerInRange)
        {
            playerInRange = true;
            UIPanel.GetComponent<Animator>().Play("UIPanelAnimOn");
        } else if (Vector3.Distance(playerTransform.position, buildingTransform.position) > activeDistance && playerInRange)
        {
            playerInRange = false;
            UIPanel.GetComponent<Animator>().Play("UIPanelAnimOff");
        }
        if (playerInRange)
        {
            xDistance = buildingUIPanelPivot.position[0] - playerTransform.position[0];
            yDistance = buildingUIPanelPivot.position[2] - playerTransform.position[2];
            angle = -Mathf.Atan2(yDistance, xDistance) * Mathf.Rad2Deg;
            buildingUIPanelPivot.eulerAngles = new Vector3(0.0f, angle, 0.0f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Bridge.bridgeStatus)
                {
                    Bridge.setBridgeDown();

                } else
                {
                    Bridge.setBridgeUp();

                }
            }
        }
	}
}
