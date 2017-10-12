using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireScript : MonoBehaviour {

	//bullet information
	public float fireTime = 0.05f;
	public GameObject bullet; 

	//To find player position
	public GameObject player;
	private Transform playerTransform;

	//To get script for point radius
	public GameObject lvlManager;
	levelManager levelManager;
	public float checkPointRadius;

	private bool firing;

	//pooling information
	public int pooledAmount = 20;  //Total number of bullets play can have active at 1 time
	List<GameObject> bullets;

	// Use this for initialization
	void Start () {

		//Get player and Information
		player = GameObject.Find("Player");
		playerTransform = player.GetComponent<Transform>();

		//Get LevelManager and Information
		lvlManager = GameObject.Find("lvlMan");
		levelManager = lvlManager.GetComponent<levelManager>();
		//checkPointRadius = levelManager.checkPointRadius;
		//print(checkPointRadius);

		bullets = new List<GameObject>(); //instantiating the list
		firing = false;

		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(bullet); //creating a bullet for the pool
			obj.SetActive(false); //setting the bullet as inactive
			bullets.Add(obj); //adding it to the bullet pool
		} 
		
	}
	
	// Update is called once per frame
	void Update () {

		if (checkPointRadius == 0) {
			checkPointRadius = levelManager.checkPointRadius;
			//print(checkPointRadius);
		}

		//if player x is within point radius shoot at player 
		float xDifference = playerTransform.position.x - transform.position.x;
		xDifference = Mathf.Abs(xDifference);
		if (xDifference <= checkPointRadius && (firing == false)) {
			firing = true;
			StartCoroutine(Fire());
		}
		
	}

	IEnumerator Fire () {
		//int nextBullet = 0;

		for (int i = 0; i < bullets.Count; i++) {
			if (!bullets[i].activeInHierarchy) {
				//set the rotation, position, and as active then break bc do not want to create multiple bullets
				bullets[i].transform.position = transform.position;
				bullets[i].transform.rotation = transform.rotation;
				bullets[i].SetActive(true);
				//firing = false;
				yield return new WaitForSeconds(1f);
				firing = false;
				break;
			}
		}
		//yield return new WaitForSeconds(2f);
	}

}
