using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFlyScript : MonoBehaviour {

	//public float speed = 200f;
	public int speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, speed, 0);
	}
}
