using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGround : MonoBehaviour {

	public GameObject removeGroundMark;

	// Use this for initialization
	void Start ()
	{
		//game object.find finds any object inside the quotes
		removeGroundMark = GameObject.Find ("RemoveGroundMark");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the mark is far enough behind us we will get rid of it so we can save memory.
		if (transform.position.x < removeGroundMark.transform.position.x) 
		{
			Destroy (gameObject);
		}

	}
}
