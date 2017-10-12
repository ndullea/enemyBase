using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiBombs : MonoBehaviour {

	public GameObject player;
	shootBomb bomber;
	private UnityEngine.UI.Text words;

	// Use this for initialization
	void Start () {
		words = GetComponent<UnityEngine.UI.Text> ();
		player = GameObject.Find ("Player");
		bomber = player.GetComponent<shootBomb> ();
	}
	
	// Update is called once per frame
	void Update () {
		words.text = bomber.bombs.ToString ();
	}
}
