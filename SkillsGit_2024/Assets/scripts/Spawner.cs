﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject Alter;
	public 	bool Spawned;
	public Vector3 SpawnedPosition;


	// Use this for initialization
	void Start () 
	{
		Spawned = false;
		SpawnedPosition = new Vector3 (-5.62f, 3.78f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnAlter() {
		
	if (Spawned == false) 
	{
		Instantiate(Alter, SpawnedPosition, Quaternion.identity);
		Spawned = true;
		Debug.Log ("Alter Spawned");
	}

}
}