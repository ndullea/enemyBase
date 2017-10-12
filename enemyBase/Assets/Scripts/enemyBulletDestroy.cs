using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletDestroy : MonoBehaviour {

	void OnEnable() { //When the bullet is created 
		//print("Envoking");
		Invoke ("Destroy", 2f); //use method detroy in 2 seconds because bullet should not exist in that long
	}

	void Destroy() {
		gameObject.SetActive(false); //makes object not active
	}

	void OnDisable() {
		CancelInvoke(); //if object deactivated for reasons other then onEnable() we dont want to deadctivate it twice
	}

	void OnTriggerEnter2D(Collider2D thing) {
		//print ("bullet collided1");
	//		print (thing);
		if (thing.gameObject.layer == LayerMask.NameToLayer ("Walls")) {
			Destroy();
			OnDisable();
		}
		else if (thing.gameObject.tag == "Player") {
			Destroy();
			OnDisable();
			//print("hit Player");
		}
	}
}
