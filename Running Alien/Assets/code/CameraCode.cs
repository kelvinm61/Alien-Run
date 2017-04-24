using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour {

	public PlayerControl alien;
	//vector 3 has 3 values, xyz.
	private Vector3 alienPostion;
	private float movingDistance;

	// Use this for initialization
	void Start () {
		alien = FindObjectOfType<PlayerControl> (); 
		//vector xyz
		alienPostion = alien.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//simple math to show how far to move with the camera.
		movingDistance = alien.transform.position.x - alienPostion.x;
		//making camera move from left to right but not up and down.
		transform.position = new Vector3 (transform.position.x + movingDistance, transform.position.y, transform.position.z);
			
		//vector xyz
		alienPostion = alien.transform.position;
	}
}
