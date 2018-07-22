using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour {
	void Awake() {
		// when we go back to menu it creates another copy 
		// we should delete the new one
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
		if (objs.Length > 1)
			Destroy (this.gameObject);

		DontDestroyOnLoad (this.gameObject);
	}
}
