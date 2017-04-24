using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public Transform groundGenerator;
	private Vector3 groundStartPoint;

	public PlayerControl player;
	private Vector3 playerStartMark;

	private Scorekeeper theScorekeeper;
	// Use this for initialization
	void Start () {
		groundStartPoint = groundGenerator.position;
		playerStartMark = player.transform.position; 
		theScorekeeper = FindObjectOfType<Scorekeeper> ();
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
		// score stop 
		theScorekeeper.scoreIncrease = false;
		//makes the player inactive
		player.gameObject.SetActive (false);
		//delay
		yield return new WaitForSeconds (0.5f);
		player.transform.position = playerStartMark;
		groundGenerator.position = groundStartPoint;
		//makes player active again
		player.gameObject.SetActive (true);
		//restarts the score at 0.
		theScorekeeper.scoreCount = 0;
		theScorekeeper.scoreIncrease = true;
	}


}
