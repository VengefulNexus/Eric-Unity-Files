using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthSliderScript : MonoBehaviour {
    public Slider sliderObject;
    public HUD_Data_Holder HUDValues;

    // Use this for initialization
    void Start()
    {
        sliderObject.value = HUDValues.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        sliderObject.value = HUDValues.playerHealth;
    }
}
