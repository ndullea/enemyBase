using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiEnemyHealth : MonoBehaviour {

	public GameObject enemyBase;
	enemyBaseHealth baseHealth;
	UnityEngine.UI.Text words;

	// Use this for initialization
	void Start () {
		words = GetComponent<UnityEngine.UI.Text> ();
		enemyBase = GameObject.Find ("enemyBase");
		baseHealth = enemyBase.GetComponent<enemyBaseHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		words.text = baseHealth.health.ToString ();
	}
}
