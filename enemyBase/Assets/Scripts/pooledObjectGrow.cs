using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooledObjectGrow : MonoBehaviour {

	public static pooledObjectGrow growScript; 
	public GameObject pooledObject;
	private int pooledAmount = 4;
	List<GameObject> pooledObjects;

	//Can set maximum of will grow too
	private bool willGrow; 
	public int timeToWait;
	//private bool previousStateWillGrow = true;
	//private bool poolHasGrown = false; 
	float timeStart;
	float currentTime;



	void Awake() {
		growScript = this;
	}

	// Use this for initialization
	void Start () {
		willGrow = false;
		timeToWait = 5;
		timeStart = Time.time;
		//print ("Timer: " + timeStart);
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			//print ("making pooled objects: " + i);
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	void Update () {
		//waitToAllowGrow ();
	}

	//Generic object pool that can grow. It also instantiates the objects. 
	public GameObject GetPooledObject () {

		for (int i = 0; i < pooledAmount; i++) {
			if (!pooledObjects [i].activeInHierarchy) {
				//print ("it keeps returning more!" + i);
				//pooledObjects[i].SetActive(true);
				return pooledObjects[i];
			}
		}

		waitToAllowGrow ();

		//THIS IS THE ON THAT WORKS?
		if (willGrow) {
			timeStart = Time.time;
			//print ("it will grow?");
			GameObject obj = (GameObject)Instantiate (pooledObject);
			pooledObjects.Add (obj);
			//print ("pooled objects size: " + pooledObjects.Count);
			return obj;
		} else {
			//print ("it will not grow");
		}
			
		return null;
	}

	void waitToAllowGrow() {
		currentTime = Time.time;
		var timeSince = Mathf.RoundToInt(currentTime - timeStart);
		//print ("timeSince: " + timeSince);

		if (timeSince >= timeToWait) {
			willGrow = true;
		} else {
			willGrow = false;
		}
	}


}
