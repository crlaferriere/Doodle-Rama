﻿using UnityEngine;
using System.Collections;

public class RotateInPlace : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, 80 * Time.deltaTime);
	}
}
