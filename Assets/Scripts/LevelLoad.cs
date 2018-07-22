using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

	public string scenceToLoad = "";
	public static float totalTime;

	public void LoadTheLevel() {
		if (scenceToLoad == "easy")
			totalTime = 61f;
		else if (scenceToLoad == "normal")
			totalTime = 121f;
		else if (scenceToLoad == "hard")
			totalTime = 301f;
		SceneManager.LoadScene (scenceToLoad);
	}
}
