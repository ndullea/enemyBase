using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDestroy : MonoBehaviour {

	public float healthCoinLife;

	// Use this for initialization
	void Start () {
		healthCoinLife = 3f;
		Invoke ("Destroy", healthCoinLife); //use method detroy in 2 seconds because bullet should not exist in that long
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Destroy() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D thing) {
		if (thing.gameObject.tag == "Player") {
			CancelInvoke ();
			Destroy(gameObject);
		}
	}
}
