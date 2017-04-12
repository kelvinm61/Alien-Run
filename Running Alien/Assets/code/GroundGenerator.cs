﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

	public GameObject theGround;
	public Transform generateMark;
	public float distanceBetween;

	private float groundWidth;


	// Use this for initialization
	void Start () {
		//
		groundWidth = theGround.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		// if this is true it will create new platforms, it will also stop creating them past that mark.
		if (transform.position.x < generateMark.position.x) 
		{
			//moved the platform widht, and left space in between with this line making sure of no overlapping..
			transform.position = new Vector3 (transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);
		//creates copy of the ground
			Instantiate (theGround, transform.position, transform.rotation);
		}
		
	}
}