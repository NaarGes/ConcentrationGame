using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteGame : MonoBehaviour {

	static bool isMute = false;
	public AudioSource Audio;

	public void muteUnmute() {
		if (isMute == false) {
			Audio.mute = true;
			isMute = true;
		} else {
			Audio.mute = false;
			isMute = false;
		}
		DontDestroyOnLoad (Audio); //doesn't work!
	}
}
