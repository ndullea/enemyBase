using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwarm : MonoBehaviour {

	public float fireTime = 0.5f;

	// Use this for initialization
	void Start () {
		//print ("enemy swarm?");
		InvokeRepeating ("swarm", fireTime, fireTime);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void swarm () {

		/*
		GameObject obj;
		try {
			obj = pooledObjectGrow.growScript.GetPooledObject ();
		}
		catch (NullReferenceException e){
			print (e);
			return;
		}*/

		GameObject obj = pooledObjectGrow.growScript.GetPooledObject ();

		if (obj == null)
			return;
		


		obj.transform.rotation = transform.rotation;
		obj.transform.position = transform.position;
		obj.SetActive(true);


		//print (pooledObjectGrow.growScript.GetPooledObject ());

	}
}
