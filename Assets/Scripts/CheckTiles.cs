using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTiles : MonoBehaviour {
	public List<Transform> pickedTiles;
	public bool disableTiles = false;
	public float waitTime = 1.5f;

	public void TileFlippedOver(Transform tileFlipped) {
		pickedTiles.Add (tileFlipped);

		if (pickedTiles.Count == 2) {
			disableTiles = true;
			DoTilesMatch ();
		}
	}

	public void DoTilesMatch() {
		if (pickedTiles [0].transform.name == pickedTiles [1].transform.name) {
			//Debug.Log ("tiles match");
			StartCoroutine (RemoveMatchingTiles ());
		} else {
			//Debug.Log ("tiles don't match");
			StartCoroutine (ReturnTiles());
		}
	}

	public IEnumerator RemoveMatchingTiles() {
		yield return new WaitForSeconds (waitTime);
		foreach (Transform tile in pickedTiles) {
			Destroy (tile.gameObject);
		}
		ResetSelection ();
		FindObjectOfType<MatchCounter> ().UpdateMatches ();
	}

	public IEnumerator ReturnTiles() {
		yield return new WaitForSeconds (waitTime);
		foreach (Transform tile in pickedTiles) {
			tile.GetComponent<flipTiles> ().FlipTileDown ();
		}
		ResetSelection ();
	}

	public void ResetSelection() {
		pickedTiles.Clear ();
		disableTiles = false;
	}
}
