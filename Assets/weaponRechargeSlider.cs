using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponRechargeSlider : MonoBehaviour {
    public Slider sliderObject;
    public HUD_Data_Holder HUDValues;

    // Use this for initialization
    void Start ()
    {
        sliderObject.value = HUDValues.weaponRecharge;
    }
	
	// Update is called once per frame
	void Update () {
        sliderObject.value = HUDValues.weaponRecharge;
	}
}
