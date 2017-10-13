using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class explosionController : MonoBehaviour {

	public Sprite[] frames;

	private SpriteRenderer rend;
	private float timePerFrame = 0.1f;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
		rend.sprite = frames [0];

		StartCoroutine (Explode ());
	}

	IEnumerator Explode() {
		yield return new WaitForSeconds (timePerFrame);
		for (int i = 1; i < frames.Length; i++) {
			rend.sprite = frames [i];
			yield return new WaitForSeconds (timePerFrame);
		}
		//Destroy (gameObject);
		SceneManager.LoadScene("endScene");
	}

}
