using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Charge_Slider_Script : MonoBehaviour {
    public Image sliderImage;
    public Slider sliderObject;
    public HUD_Data_Holder HUDValues;
    float hValue;

    // Use this for initialization
    void Start () {
        sliderObject.value = HUDValues.weaponCharge;
    }
	
	// Update is called once per frame
	void Update () {
        sliderObject.value = HUDValues.weaponCharge;
    }

    public void updateBar()
    {
        //sliderImage.fillAmount = sliderObject.GetComponent<Slider>().value;
        hValue = (sliderObject.value * 50) / 255;
        sliderImage.color = Color.HSVToRGB(hValue, 1.0f, 1.0f);
    }
}
