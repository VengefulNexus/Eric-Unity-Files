﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(-0.5f, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, -0.5f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, 0.5f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0.5f, 0.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0.0f, -0.5f, 0.0f));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0.0f, -1.5f, 0.0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0.0f, 1.5f, 0.0f));
        }
	}
}
