using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeControlUI : MonoBehaviour {
    public Transform buildingUIPanelPivot;
    public Transform playerTransform;
    public Transform buildingTransform;
    public GameObject UIPanel;
    float xDistance;
    float yDistance;

    float activeDistance = 20.0f;

    float angle = 0.0f;
    bool playerInRange = false;

    bool runOnAnim = false;
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {




        if (Vector3.Distance(playerTransform.position, buildingTransform.position) < activeDistance)
        {
            playerInRange = true;
        } else
        {
            playerInRange = false;
        }
        if (playerInRange)
        {
            if (!UIPanel.activeSelf)
            {
                UIPanel.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                UIPanel.SetActive(true);
                runOnAnim = true;
            }
            xDistance = buildingUIPanelPivot.position[0] - playerTransform.position[0];
            yDistance = buildingUIPanelPivot.position[2] - playerTransform.position[2];
            angle = -Mathf.Atan2(yDistance, xDistance) * Mathf.Rad2Deg;
            buildingUIPanelPivot.eulerAngles = new Vector3(0.0f, angle, 0.0f);
        } else
        {
            if (UIPanel.activeSelf)
            {
                UIPanel.SetActive(false);
            }
        }
	}
}
