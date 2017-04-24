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

	private float minHeight;
	public Transform maxHeightMark;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;
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

		minHeight = transform.position.y; 
		maxHeight = maxHeightMark.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		
		// if this is true it will create new platforms, it will also stop creating them past that mark.
		if (transform.position.x < generateMark.position.x) 
		{   
			//generate random number for gaps
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			groundSelector = Random.Range (0, grounds.Length); 
			//changes the height positions of the ground.
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			// statement stops the ground leaving the camera area
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}

				//moved the platform width, and left space in between with this line making sure of no overlapping..
			transform.position = new Vector3 (transform.position.x + groundWidths[groundSelector]  + distanceBetween, heightChange, transform.position.z);
		

				//creates copy of the ground
			Instantiate (grounds[groundSelector], transform.position, transform.rotation);
		}
		
	}
} 
