﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Camera.main.transform.eulerAngles);
        Debug.Log(transform.eulerAngles);
	}
}
