using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D thing) {
		//print ("bullet collided");
		if (thing.gameObject.layer == LayerMask.NameToLayer ("Walls")) {
			Destroy (gameObject);
		}
		else if (thing.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			Destroy (gameObject);
		}
	}
}
