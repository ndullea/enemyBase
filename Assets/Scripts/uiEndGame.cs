using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiEndGame : MonoBehaviour {

	private UnityEngine.UI.Text words;
	int score;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("playerHealth");
	}
	
	// Update is called once per frame
	void Update () {
		if (score > 0) {
			words.text = ":)";
		} else {
			words.text = ":(";
		}
	}
}
