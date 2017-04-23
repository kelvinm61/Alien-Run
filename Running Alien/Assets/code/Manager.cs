using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour {

	public Transform groundGenerator;
	private Vector3 groundStartPoint;

	public PlayerControl player;
	private Vector3 playerStartMark;

	private Scores thescore;
	// Use this for initialization
	void Start () {
		groundStartPoint = groundGenerator.position;
		//ground generater is already a transform from above
		playerStartMark = player.transform.position; 

		//thescore = FindObjectOfType<Scores>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// restarts game with a time delay
	public void RestartGame()
	{
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo() 
	{

		thescore.scoreIncrease = false;
		//makes the player inactive
		player.gameObject.SetActive (false);
		//delay
		yield return new WaitForSeconds (0.5f);
		player.transform.position = playerStartMark;
		groundGenerator.position = groundStartPoint;
		//makes player active again
		player.gameObject.SetActive (true);
		thescore.scoreCount = 0;
		thescore.scoreIncrease = true;
	}


}
