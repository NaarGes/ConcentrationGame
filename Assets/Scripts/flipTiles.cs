using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipTiles : MonoBehaviour {

	// flags for specifing cards when need to be rotated
	public bool flipUp = false;
	public bool flipDown = false;

	// angles we want to card to flip to
	Vector3 downAngle;
	Vector3 flippedAngle;

	// for the animation
	float timeToRotate = 0.75f; 
	float startTime;

	// Use this for initialization
	void Start () {
		downAngle = transform.eulerAngles;
		flippedAngle = downAngle + 180f * Vector3.up; //180*(0,1,0)
	}
	
	// Update is called once per frame
	void Update () {
		if (flipUp == true) {
			transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, flippedAngle, (Time.time - startTime) / timeToRotate);
			if (transform.eulerAngles == flippedAngle)
				flipUp = false;
		}
		if (flipDown == true) {
			transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, downAngle, (Time.time - startTime) / timeToRotate);
			if (transform.eulerAngles == downAngle)
				flipDown = false;
		}
		
	}

	public void OnMouseDown() {
		//Debug.Log ("press");
		startTime = Time.time;
		if (transform.eulerAngles == downAngle) {
			if(FindObjectOfType<CheckTiles>().disableTiles == false){
				flipUp = true;
				FindObjectOfType<CheckTiles>().TileFlippedOver (transform);
			}
		}
	}

	public void OnMouseUp() {
		//Debug.Log ("release");
		//transform.Rotate(0,180,0); // one way to rotate without animation
	}

	public void FlipTileDown() {
		startTime = Time.time;
		flipDown = true;

	}

	public void FlipTileUp() {
		startTime = Time.time;
		flipUp = true;

	}

}
