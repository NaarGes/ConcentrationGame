using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {
	
	float minutes=0f;
	float seconds=0f;
	public float timeCounter = 0f;
	float startTime=0f;
	Text timeTextDisplay;
	public bool gameOver = false;

	void Awake(){
		timeTextDisplay = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == false) {
			timeCounter = Time.timeSinceLevelLoad - startTime;
			minutes = Mathf.Floor ((LevelLoad.totalTime - timeCounter) / 60f);
			seconds = Mathf.Floor ((LevelLoad.totalTime - timeCounter) % 60f);

			// time over
			if (seconds == 0f && minutes == 0f) {
				FindObjectOfType<MatchCounter> ().gameOver ();
			}

			if (seconds < 10) {
				timeTextDisplay.text = minutes + ":0" + seconds;
			} else {
				timeTextDisplay.text = minutes + ":" + seconds;
			}
		}
	}
}
