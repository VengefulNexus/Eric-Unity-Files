using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Data_Holder : MonoBehaviour {
    public float weaponCharge;
    public float playerHealth;
    public float weaponRecharge;
    public int rightHUDScreen;
	// Use this for initialization
	void Start () {
		// GET INITIAL VALUES FROM SOMEWHERE AS RESULT OF TECH TREE
	}
	
	// Update is called once per frame
	void Update () {

		// PULL VALUES FROM ANOTHER SCRIPT WHERE THEY ARE UPDATED AFTER BEING SHOT, HEALING, ETC ( or push values to these variables)
	}
}
