 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {

	public Text score;
	public Text highscore;

	public float scoreCount;
	public float highscoreCount;

	public float pointpersec;
	public bool scoreIncrease;
	// Use this for initialization
	void Start () { 
		
		//to show highscore if one has already been set.
		if (PlayerPrefs.HasKey("Highscore")) {
			highscoreCount = PlayerPrefs.GetFloat ("Highscore");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//adds score per second
		if (scoreIncrease) {
			
			scoreCount += pointpersec * Time.deltaTime;
		}
		if (scoreCount > highscoreCount)
		{
			highscoreCount = scoreCount;
			//set high score and it to be saved
			PlayerPrefs.SetFloat ("Highscore", highscoreCount);
		}
		//adds score to screen ....mathf.round rounds score to whole number
		score.text = "Score: " + Mathf.Round (scoreCount);
		highscore.text = "Highscore: " + Mathf.Round (highscoreCount);
		
	}
}
