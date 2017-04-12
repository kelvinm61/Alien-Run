using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour 
{

	public GameObject theGround;
	public Transform generateMark;
	public float distanceBetween;

	private float groundWidth;


	public float distanceBetweenMin;
	public  float distanceBetweenMax;

	//array to choose all the platforms not just one length
	public GameObject[] grounds;
	private int groundSelector;
	private float[] groundWidths;

	// Use this for initialization
	void Start () 
	{
		//
		//groundWidth = theGround.GetComponent<BoxCollider2D>().size.x;
		groundWidths = new float[grounds.Length];
		//for loop to determine the collision on the different sized platforms
		for (int i = 0; i < grounds.Length; i++) 
		{
			groundWidths[i] = grounds[i].GetComponent<BoxCollider2D>().size.x; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// if this is true it will create new platforms, it will also stop creating them past that mark.
		if (transform.position.x < generateMark.position.x) 
		{   
			//generate random number for gaps
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, grounds.Length); 

				//moved the platform widht, and left space in between with this line making sure of no overlapping..
			transform.position = new Vector3 (transform.position.x + groundWidths[groundSelector]  + distanceBetween, transform.position.y, transform.position.z);
		

				//creates copy of the ground
			Instantiate (grounds[groundSelector], transform.position, transform.rotation);
		}
		
	}
} 
