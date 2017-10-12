using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D thing) {
		//Destroy(gameObject);
		if (thing.gameObject.layer == LayerMask.NameToLayer ("Walls")) {
			gameObject.SetActive(false); //makes object not active
			//Destroy();
		}
		else if (thing.gameObject.tag == "Player") {
			gameObject.SetActive(false); //makes object not active
			//Destroy(gameObject);
		}
		else if (thing.gameObject.tag == "bullet") {
			gameObject.SetActive(false); //makes object not active
			//Destroy(gameObject);
		}
	}

	/*void onEnable() { //When the enemy (in example it is bullets) is created 
		Invoke ("Destroy", 2f); //use method detroy in 2 seconds because bullet should not exist in that long
	}*/

	void Destroy() {
		gameObject.SetActive(false); //makes object not active
	}

	/*void onDisable() {
		CancelInvoke(); //if object deactivated for reasons other then onEnable() we dont want to deadctivate it twice
	}*/
}
