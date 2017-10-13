using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiTime : MonoBehaviour {

	public GameObject levelMan;
	levelManager lvl;
	private UnityEngine.UI.Text words;

	// Use this for initialization
	void Start () {
		words = GetComponent<UnityEngine.UI.Text> ();
		levelMan = GameObject.Find ("lvlMan");
		lvl = levelMan.GetComponent<levelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		words.text = (Time.time - lvl.startTime).ToString ();
		int time = Mathf.RoundToInt(Time.time - lvl.startTime);
		PlayerPrefs.SetInt("time", time);
	}
}
