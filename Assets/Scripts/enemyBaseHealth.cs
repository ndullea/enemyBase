using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyBaseHealth : MonoBehaviour {

	public int health;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		health = 40;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//animation.Play();
			//StartCoroutine(Explode());
			//SceneManager.LoadScene("endScene");
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D thing) {
		if (thing.gameObject.tag == "bullet") {
			//print ("healthCoin");
			health = health - 1;
		} else if (thing.gameObject.tag == "bomb") {
			health = health - 10;
		}
	}



	/*IEnumerator Explode () {
		yield return new WaitForSeconds (timePerFrame);
		for (int i = 1; i < frames.Length; i++) {
			spRend.sprite = frames [i];
			yield return new WaitForSeconds (timePerFrame);
		}
		//Destroy (gameObject);
		SceneManager.LoadScene("endScene");
	}*/
}
