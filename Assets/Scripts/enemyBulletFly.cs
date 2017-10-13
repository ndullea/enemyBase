using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletFly : MonoBehaviour {


	//Find player position 
	//Use lerp to slowly move towards that position? 

	public GameObject player;
	private Transform playerTransform;

	private Vector3 origin;
	//private Vector3 destination;
	private float tenthDistance;

	public float speed;

	// Use this for initialization
	void Start () {

		speed = 5;

		//Get player and Information
		player = GameObject.Find("Player");
		playerTransform = player.GetComponent<Transform>();

		//origin = transform.position;
		//destination = playerTransform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(0, speed, 0);
		float move = speed * Time.deltaTime * 3;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, move);
	}
}
