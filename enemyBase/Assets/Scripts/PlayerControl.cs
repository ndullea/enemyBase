using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


	public static PlayerControl playercontrol;
	//Controlling Movement of player
	private Rigidbody2D rgb;
	public float floatSpeed = 20f;
	public int direction = 3; //1 = left, 2 = right, 3 = up, 4 = down


	void Awake() {
		playercontrol = this;
	}

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		//print ("start");
		//Debug.Log ("startttt");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("left")) {
			direction = 1;
		}
		else if (Input.GetKeyDown("right")) {
			direction = 2;
		} 
		else if (Input.GetKeyDown("up")) {
			direction = 3;
		}
		else if (Input.GetKeyDown("down")) {
			direction = 4;
		}

		//Gettin input from horizontal and vertical axis
		float inX = Input.GetAxis("Horizontal");
		float inY = Input.GetAxis("Vertical");

		//Fixing velocity based on directional input
		switch (direction) {
			case 1:
				rgb.velocity = new Vector2 (inX * floatSpeed, 0);
				break;
			case 2:
				rgb.velocity = new Vector2 (inX * floatSpeed, 0);
				break;
			case 3:
				rgb.velocity = new Vector2 (0, inY * floatSpeed);
				break;
			case 4:
				rgb.velocity = new Vector2 (0, inY * floatSpeed);
				break;
		}

		//Fixing direction player faces based on velocity
		if (rgb.velocity.x != 0) {
			if (rgb.velocity.x < 0 ) {
				rgb.MoveRotation (90f);
			}
			else if (rgb.velocity.x > 0) {
				rgb.MoveRotation (270f);
			}
		
		} else if (rgb.velocity.y != 0) {
			if (rgb.velocity.y > 0) {
				rgb.MoveRotation (0f);
			} else if (rgb.velocity.y < 0) {
				rgb.MoveRotation (180f);
			}
		}

		//Maybe need another piece to check z rotation of sprite transform?
	
	}
}

