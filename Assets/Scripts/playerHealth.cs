using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerHealth : MonoBehaviour {

	public int health;
	public int bulletDamage;
	public int enemyDamage;
	public int healthCoinValue;

	// Use this for initialization
	void Start () {
		health = 40;
		bulletDamage = 2;
		enemyDamage = 4;
		healthCoinValue = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			SceneManager.LoadScene("endScene");
		}
	}

	void OnTriggerEnter2D(Collider2D thing) {
		if (thing.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			//print ("Hit by enemy");
			health = health - enemyDamage;
		} else if (thing.gameObject.layer == LayerMask.NameToLayer ("enemyBullet")) {
			//print ("Hit by enemy bullet");
			health = health - bulletDamage;
		} else if (thing.gameObject.tag == "healthCoin") {
			//print ("healthCoin");
			health += healthCoinValue;
		} 
		PlayerPrefs.SetInt ("playerHealth", health);
	}
}
