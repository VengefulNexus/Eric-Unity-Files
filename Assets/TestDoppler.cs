using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoppler : MonoBehaviour {
    public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(speed, 0.0f, 0.0f);
	}
}
