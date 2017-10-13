using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFireScript : MonoBehaviour {

	//bullet information
	public float fireTime = 0.05f;
	public GameObject bullet; 

	//player information for properly orienting bullet
	PlayerControl playerControl; //1 = left, 2 = right, 3 = up, 4 = down
	private int playerDirection;
	private Transform playerTransform;
	public int spriteSize = 5;

	//pooling information
	public int pooledAmount = 20;  //Total number of bullets play can have active at 1 time
	List<GameObject> bullets;


	// Use this for initialization
	void Start () {
		//Getting information on player
		playerTransform = GetComponent<Transform>(); 
		playerControl = GetComponent<PlayerControl> ();
		//print("playerDirection");

		bullets = new List<GameObject>(); //instantiating the list

		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(bullet); //creating a bullet for the pool
			obj.SetActive(false); //setting the bullet as inactive
			bullets.Add(obj); //adding it to the bullet pool
		} 

		//InvokeRepeating("Fire", fireTime, fireTime);
		
	}
	
	// Update is called once per frame
	void Update () {
		//updating player direction
		playerDirection = playerControl.direction;


		//it space button down then shoot
		if (Input.GetButtonDown("Jump")) {
			Fire(playerDirection);
		}
	}

	void Fire (int direction) {

		var spritePosition = playerTransform.position;
		var spriteRotation = playerTransform.rotation;

		int nextBullet = 0;

		//Find a bullet not currently in use
		for (int i = 0; i < bullets.Count; i++) {
			//if the bullet is not active
			if (!bullets[i].activeInHierarchy) {
				nextBullet = i;
				break;
			}
		}

		switch (direction) {
			case 0:
				//print("case 000000 not good"); 
				break;
			case 1:
				spritePosition.x = spritePosition.x - spriteSize;
				//print("instantiated bullet");
				break;
			case 2:
				spritePosition.x = spritePosition.x + spriteSize;
				//print("instantiated bullet");
				break;
			case 3:
				spritePosition.y = spritePosition.y + spriteSize;
				//print("instantiated bullet");
				break;
			case 4:
				//var position = transform.position;
				spritePosition.y = spritePosition.y - spriteSize;
				//print("instantiated bullet");
				break;
		}

		bullets[nextBullet].transform.position = spritePosition;
		bullets[nextBullet].transform.rotation = spriteRotation;
		bullets[nextBullet].SetActive(true);
	}
}
