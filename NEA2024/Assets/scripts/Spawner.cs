using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject Alter;
	bool Spawned;
	public Vector3 SpawnedPosition;

	// Use this for initialization
	void Start () {
		Spawned = false;
		SpawnedPosition = new Vector3 (75.5f, -1.15f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnAlter()
	{

		if (Spawned == false)
		{
			Instantiate (Alter, SpawnedPosition, Quaternion.identity);
			Spawned = true;
			Debug.Log ("Alyter spawned");
		}
	}
		
}
