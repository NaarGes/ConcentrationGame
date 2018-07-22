using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTiles : MonoBehaviour {

	public List<GameObject> tiles;
	public List<GameObject> tilesInGame;
	private GameObject tempValue;
	public int columnCount;
	private int randomPos;
	private float initialX = 0, initialY = 0;
	private Vector2 tileLocation;

	void Start () {
		// create game board
		ShuffleTheTiles ();
		StartCoroutine(FlipOver());
	}
		
	public void ShuffleTheTiles() {
		for (int i = tiles.Count - 1; i > 0; i--) {
			randomPos = Random.Range (0, i);
			tempValue = tiles [randomPos];
			tiles [randomPos] = tiles [i];
			tiles [i] = tempValue;
		}
		PlaceTheTiles ();
	}

	public void PlaceTheTiles() {
		// even columns
		if (columnCount % 2 == 0)
			initialX =- (columnCount / 2)+0.5f;
		// odd columns
		else
			initialX =- (columnCount / 2);
		
		Debug.Log (Mathf.Ceil (tiles.Count / (float)columnCount));
		// even rows
		if (Mathf.Ceil (tiles.Count / (float)columnCount) % 2 == 0)
			initialY = (Mathf.Ceil (tiles.Count / (float)columnCount)) / 2 - 0.5f;
			// odd rows
		else
			initialY = (Mathf.Ceil (tiles.Count / (float)columnCount)) / 2;
			
		for (int i = 0; i < tiles.Count; i++) {
			tileLocation = new Vector2 (initialX + (i % columnCount), initialY - (i / columnCount));
			tilesInGame.Add(Instantiate (tiles [i], tileLocation, Quaternion.identity));   // when we dont want rotation we use Quarnion.identity
		}
		FindObjectOfType<MatchCounter> ().InitializeMatches (tiles.Count / 2);
	}

	public IEnumerator FlipOver() {
		yield return new WaitForSeconds (1);
		for (int i = tiles.Count - 1; i >= 0; i--) {
			tilesInGame[i].GetComponent<flipTiles>().FlipTileUp();
		}
		yield return new WaitForSeconds (5);
		for (int i = tiles.Count - 1; i >= 0; i--) {
			tilesInGame[i].GetComponent<flipTiles>().FlipTileDown();
		}
	}
}
