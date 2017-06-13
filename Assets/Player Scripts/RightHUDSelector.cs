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
		switch (HUDValues.rightHUDScreen)       //use the value from the HUDValues script to determine which right hud to display
        {
            case 1:     //enable map view
                Healths.SetActive(false);       //disable health panel, and enable map panel and translucent background
                Map.SetActive(true);
                Background.enabled = true;
                break;
            case 2:     // enable building health view
                Healths.SetActive(true);        //disable map panel, and enable health panel and translucent background
                Map.SetActive(false);
                Background.enabled = true;
                break;
            case 0:     //disable right hud
                Healths.SetActive(false);        //disable health panel, map panel, and translucent background to show nothing for the right hud
                Map.SetActive(false);
                Background.enabled = false;
                break;
            default:
                Healths.SetActive(false);       //by default hide everything, and print an error to say the switch was passed an invalid value
                Map.SetActive(false);
                Background.enabled = false;
                print("RightHUDSelector.cs: Invalid switch value");
                break;
        }
	}
}
