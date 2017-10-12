using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBomb : MonoBehaviour {

	public int toolCount;
	public int bombs;
	public int toolsToBombs;
	private int direction; 
	public GameObject bomb;

	// Use this for initialization
	void Start () {
		toolCount = 0;
		bombs = 2;
		toolsToBombs = 2;
		direction = PlayerControl.playercontrol.direction;
	}
	
	// Update is called once per frame
	void Update () {
		if (toolCount >= toolsToBombs) {
			print ("adding a bomb");
			bombs += 1;
			toolCount -= toolsToBombs;
		} else {
			//print ("not adding a bomb");
		}

		direction = PlayerControl.playercontrol.direction;

		if (Input.GetKeyDown(KeyCode.B)) {
			fireBomb();
		}
	}

	void fireBomb () {
		print ("firing");
		if (bombs > 0) {
			GameObject obj = (GameObject)Instantiate (bomb, transform.position, transform.rotation);
			bombs = bombs - 1;
			print ("Shot a bomb");
		}
	}

	void OnTriggerEnter2D(Collider2D thing) {
		if (thing.gameObject.tag == "tools") {
			print ("picked up tools");
			toolCount += 1;
		}
	}
}
