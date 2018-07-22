using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCounter : MonoBehaviour {

	public int matchesRemaining;
	public Text matchesTextBox;
	public CanvasGroup replayButton;
	public Text win;

	public void InitializeMatches(int initialMatches){
		matchesRemaining = initialMatches;
		matchesTextBox.text = "Matches Remaining = " + matchesRemaining.ToString ();
	}

	public void UpdateMatches() {
		matchesRemaining = matchesRemaining - 1;
		matchesTextBox.text = "Matches Remaining = " + matchesRemaining.ToString ();

		if (matchesRemaining == 0) {
			//Debug.Log ("Win!!");
			GameWon ();
		}
	}

	public void GameWon() {
		win.text = "Congratulations!\nYou Won!!";
		replayButton.alpha = 1;
		replayButton.interactable = true;
		replayButton.blocksRaycasts = true;

		FindObjectOfType<Timer> ().gameOver = true;
	}

	public void gameOver() {
		win.text = "Ooops!\nYou Lose!!";
		replayButton.alpha = 1;
		replayButton.interactable = true;
		replayButton.blocksRaycasts = true;

		FindObjectOfType<Timer> ().gameOver = true;
	}
}
