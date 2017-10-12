using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

	public static levelManager lvlm;
	public GameObject[] enemyCheckPoints;
	public Vector2[] enemyCheckPointLocations; 
	public float checkPointRadius;
	public float startTime;

	void Awake() {
		lvlm = this;
		//DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		//print("start of levelManager script");
		enemyCheckPointLocations = findEnemyCheckpoints();
		checkPointRadius = findCheckPointRadius();
		//print("Radius: " + checkPointRadius);

		for (int i = 0; i < enemyCheckPointLocations.Length; i++) {
			//print("CP");
			//print("CP: " + enemyCheckPointLocations[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector2[] findEnemyCheckpoints() {
		enemyCheckPoints = GameObject.FindGameObjectsWithTag("enemyCheckPoint");
		var temp = new Vector2[enemyCheckPoints.Length];
		for (int i = 0; i < enemyCheckPoints.Length; i++) {
			temp[i] = enemyCheckPoints[i].transform.position;
			//print("Found check point");
			//print("Location :) : " + temp[i]);
		}
		return temp;
	}

	float findCheckPointRadius() {

		//might possibly need to find two points with closest distance? YEAHUP 

		float distance;
		//distance = Mathf.Abs(enemyCheckPointLocations[0].y - enemyCheckPointLocations[1].y);
		if (Mathf.Abs(enemyCheckPointLocations[0].y - enemyCheckPointLocations[1].y) == 0)
			distance = Mathf.Abs(enemyCheckPointLocations[0].x - enemyCheckPointLocations[1].x);
		else 
			distance = Mathf.Abs(enemyCheckPointLocations[0].y - enemyCheckPointLocations[1].y);

		for (int i = 1; i < enemyCheckPointLocations.Length; i++) {
			var tempY = Mathf.Abs(enemyCheckPointLocations[0].y - enemyCheckPointLocations[i].y); 
			var tempX = Mathf.Abs(enemyCheckPointLocations[0].x - enemyCheckPointLocations[i].x);
			if (tempX < distance && tempX != 0)
				distance = tempX;
			else if (tempY < distance && tempY != 0)
				distance = tempY;
		}

		return distance;
			

		/*float distance;

		print ("Location1: " + enemyCheckPointLocations [1]);
		print ("Location2: " + enemyCheckPointLocations [2]);

		if (enemyCheckPointLocations[1].x == enemyCheckPointLocations[2].x) 
			distance = Mathf.Abs(enemyCheckPointLocations[1].y - enemyCheckPointLocations[2].y);
		else 
			distance = Mathf.Abs(enemyCheckPointLocations[1].x - enemyCheckPointLocations[2].x);

		return distance;*/
	}

	void findRoutes () {

	}
}
