using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	// These are used to find the distance of the player
	public GameObject player;
	private Transform playerTransform;
	public float playerDistance;

	//controls the speed of movement
	public float speed = 5f;
	public float rightChange = 5;
	public float upChange = 5;

	//find player direction to use it to move towards it using rays or finding player

	//get levelManager enemyCheckPointLocations and enemy currentPoint
	public GameObject lvlManager;
	levelManager levelManager;
	private Vector2[] enemyCheckPointLocations;
	public Vector2 currentPoint;
	
	private bool transformPositionAtCheckPoint = true;
	private bool testing;

	private Vector2[] adjacentPoints;
	private int adjacentPointCount = 0;
	public int direction = 1; //1 = up, 2 = down, 3 = left, 4 = right

	//For dropping a coin
	public GameObject coin;
	public GameObject tools;

	// Use this for initialization
	void Start () {

		//Get player and Information
		player = GameObject.Find("Player");
		playerTransform = player.GetComponent<Transform>();

		//Get LevelManager and Information
		lvlManager = GameObject.Find("lvlMan");
		levelManager = lvlManager.GetComponent<levelManager>();

		testing = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (testing) {
			enemyCheckPointLocations = levelManager.enemyCheckPointLocations;
			findAdjacentPoints();
			testing = false;
		}
		
		//Finding the distance of the player
		playerDistance = Vector2.Distance(playerTransform.position, transform.position);
		//print("playerDistance:" + playerDistance);

		if (transformPositionAtCheckPoint) {
				findAdjacentPoints();
				moveToRandomCheckPoint();

		}
		
	}

	void moveToRandomCheckPoint() {

		var randomIndex = Mathf.RoundToInt(Random.Range(0, adjacentPoints.Length));
		//print (randomIndex);
		//print(adjacentPoints[randomIndex]);

		var dest = new Vector2(adjacentPoints[randomIndex].x, adjacentPoints[randomIndex].y);
		if (dest.x == 0 && dest.y == 0) {
			//while (dest.x == 0 && dest.y == 0) {
			var tempIndex = Mathf.RoundToInt(Random.Range(0, adjacentPoints.Length));

			if (randomIndex == tempIndex) {
				tempIndex = Mathf.RoundToInt (Random.Range (0, adjacentPoints.Length));
			} else {
				dest = new Vector2(adjacentPoints[tempIndex].x, adjacentPoints[tempIndex].y);
			}

			//print("went Home!");
			//dest = new Vector2(adjacentPoints[randomIndex].x, adjacentPoints[randomIndex].y);
			//}
		}
		transformPositionAtCheckPoint = false;
		StartCoroutine(moveSpriteRoutine(currentPoint, dest, 0.5f));
	}


	IEnumerator moveSpriteRoutine (Vector2 startSpot, Vector2 destination, float linearSpeed) {

		//Need to change orientation here so can properly send bullet
		if (startSpot.x == destination.x) {

		} else {

		}


		var tenthOfDistance = Vector2.Distance(startSpot, destination) / 10;
		//print("tenth: " + tenthOfDistance);

		while (currentPoint != destination) {
			var dest = new Vector3(destination.x, destination.y, 0);
			var distanceLeft = Vector2.Distance(currentPoint, destination);
			
			if(distanceLeft < tenthOfDistance) 
				transform.position = new Vector3(destination.x, destination.y, 0);
			 else  //Lerp to next spot 
				transform.position = Vector3.Lerp(transform.position, dest, linearSpeed);
			
			yield return new WaitForSeconds(0.2f);
			currentPoint = new Vector2(transform.position.x, transform.position.y);
		}	
		transformPositionAtCheckPoint = true;
	}


	
	void findAdjacentPoints() {
		//print("Finding adjacentPoints");
		var adjacentList = new Vector2[4];
		adjacentPointCount = 0;
		//print("length: " + enemyCheckPointLocations.Length);
		for (int i = 0; i < enemyCheckPointLocations.Length; i++) {
			if (enemyCheckPointLocations[i] != currentPoint) {
				if(enemyCheckPointLocations[i].x == currentPoint.x) {
					if ((enemyCheckPointLocations[i].y - currentPoint.y) == levelManager.checkPointRadius) {
						adjacentList[adjacentPointCount] = new Vector2(enemyCheckPointLocations[i].x, enemyCheckPointLocations[i].y);
						adjacentPointCount += 1;
					}
					else if (-(enemyCheckPointLocations[i].y - currentPoint.y) == levelManager.checkPointRadius) {
						adjacentList[adjacentPointCount] = new Vector2(enemyCheckPointLocations[i].x, enemyCheckPointLocations[i].y);
						adjacentPointCount += 1;
					}
				}
				else if (enemyCheckPointLocations[i].y == currentPoint.y) {
					if ((enemyCheckPointLocations[i].x - currentPoint.x) == levelManager.checkPointRadius) {
						adjacentList[adjacentPointCount] = new Vector2(enemyCheckPointLocations[i].x, enemyCheckPointLocations[i].y);
						adjacentPointCount += 1;
					}
					else if (-(enemyCheckPointLocations[i].x - currentPoint.x) == levelManager.checkPointRadius) {
						adjacentList[adjacentPointCount] = new Vector2(enemyCheckPointLocations[i].x, enemyCheckPointLocations[i].y);
						adjacentPointCount += 1;
					}
				}
			}
			else {
				//print("FINDING2");
			}
		}
		adjacentPoints = new Vector2[adjacentPointCount];
		for(int i = 0; i < adjacentPointCount; i++) {
			adjacentPoints[i] = adjacentList[i];
			//print("adjacents: " + adjacentPoints[i]);
		}
	}


	void OnTriggerEnter2D(Collider2D thing) {
		//Destroy(gameObject);
		if (thing.gameObject.layer == LayerMask.NameToLayer ("Walls")) {
			//Destroy(gameObject);
			gameObject.SetActive(false); //makes object not active
		}
		else if (thing.gameObject.tag == "Player") {
			//DROP A HEALTH COIN
			//GameObject coinClone = (GameObject)Instantiate(coin, transform.position, transform.rotation);

			//Destroy(gameObject);
			gameObject.SetActive(false); //makes object not active
		}
		else if (thing.gameObject.tag == "bullet") {
			//DROP A HEALTH COIN
			var random = Random.Range(0,2);
			int rand = Mathf.RoundToInt (random);

			if (rand == 0) {
				print ("tools");
				GameObject toolClone = (GameObject)Instantiate (tools, transform.position, transform.rotation);
			} else {
				//print ("coins");
				GameObject coinClone = (GameObject)Instantiate(coin, transform.position, transform.rotation);
			}
			//GameObject coinClone = (GameObject)Instantiate(coin, transform.position, transform.rotation);

			//Destroy(gameObject);
			gameObject.SetActive(false); //makes object not active
		}
	}
		



	//TEST FUNCTIONS
	void moveCheckPoint1() {
		print("MOVE CHECKPOINT1?");
		Vector3 temp = new Vector3(20, 5, 0);
		currentPoint = new Vector2(transform.position.x, transform.position.y);
		StartCoroutine(moveSpriteRoutine(currentPoint, temp, 0.5f));
	}

	void moveCheckPoint2() {
		print("MOVE CHECKPOINT12");
		Vector3 temp = new Vector3(10, 5, 0);
		currentPoint = new Vector2(transform.position.x, transform.position.y);
		StartCoroutine(moveSpriteRoutine(currentPoint, temp, 0.5f));
	}
}
