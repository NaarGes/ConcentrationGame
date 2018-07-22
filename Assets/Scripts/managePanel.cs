using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managePanel : MonoBehaviour {
	public CanvasGroup aboutUsPanel;

	public void showPanel() {
		aboutUsPanel.alpha = 1;
		aboutUsPanel.interactable = true;
		aboutUsPanel.blocksRaycasts = true;
	}

	public void hidePanel() {
		aboutUsPanel.alpha = 0;
		aboutUsPanel.interactable = false;
		aboutUsPanel.blocksRaycasts = false;
	}
}
