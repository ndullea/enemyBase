using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiPlayerHealth : MonoBehaviour {

	public GameObject player;
	playerHealth playerHealth;
	//shootBomb bomber;
	private UnityEngine.UI.Text words;


	// Use this for initialization
	void Start () {
		words = GetComponent<UnityEngine.UI.Text> ();
		player = GameObject.Find ("Player");
		playerHealth = player.GetComponent<playerHealth> ();
		//bomber = player.GetComponent<shootBomb> ();
	}
	
	// Update is called once per frame
	void Update () {
		words.text = playerHealth.health.ToString();
	}
}
