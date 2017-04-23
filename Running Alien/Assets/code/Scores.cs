using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scores : MonoBehaviour {

	public Text scoretext;
	public Text highscore;

	public float scoreCount;
	public float highscoreCount;

	public float pointspersecond;

	public bool scoreIncrease;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetFloat ("HighScore") != null)
		{
			highscoreCount = PlayerPrefs.GetFloat ("highscore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		//adds score points every second you live
		//time its taken from last increment to next one
		if (scoreIncrease) 
		{
			scoreCount += pointspersecond * Time.deltaTime;
		}
		if (scoreCount > highscoreCount) 
		{
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore", highscoreCount);
		}
		//keeps the score changing on the screen
		scoretext.text = "Score: " + Mathf.Round (scoreCount);
		highscore.text = "High Score: " + Mathf.Round (highscoreCount);
	}
}
