using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightHUDSelector : MonoBehaviour {

    public HUD_Data_Holder HUDValues;
    public Image Background;
    public GameObject Healths;
    public GameObject Map;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (HUDValues.rightHUDScreen)
        {
            case 1:     //enable map view
                Healths.SetActive(false);
                Map.SetActive(true);
                Background.enabled = true;
                break;
            case 2:     // enable building health view
                Healths.SetActive(true);
                Map.SetActive(false);
                Background.enabled = true;
                break;
            case 0:     //disable right hud
                Healths.SetActive(false);
                Map.SetActive(false);
                Background.enabled = false;
                break;
            default:
                Healths.SetActive(false);
                Map.SetActive(false);
                print("RightHUDSelector.cs: Invalid switch value");
                break;
        }
	}
}
