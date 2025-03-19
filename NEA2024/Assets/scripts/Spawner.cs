using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	public GameObject Alter;
	bool AlterSpawned;
	public Vector3 AlterSpawnedPosition;
	public GameObject EndAlter;
	public GameObject Star;
	public Vector3 MSStarSpawnedPosition;
	public Vector3 SKStarSpawnedPosition;
	public Vector3 GBStarSpawnedPosition;
	public Vector3 NBStarSpawnedPosition;

	// Use this for initialization
	void Start () {
		AlterSpawned = false;
		GameObject endAlter = GameObject.FindWithTag ("EndAlter");
		GameObject mushroom = GameObject.FindWithTag ("Mushroom");
		GameObject skeleton = GameObject.FindWithTag ("Skeleton");
		GameObject goblin = GameObject.FindWithTag ("Goblin");
		GameObject nightBorne = GameObject.FindWithTag ("NightBorne");
		AlterSpawnedPosition = new Vector3 (75.5f, -1.15f, 0);
		MSStarSpawnedPosition = mushroom.transform.position;  
		SKStarSpawnedPosition = skeleton.transform.position; 
		GBStarSpawnedPosition = goblin.transform.position; 
		NBStarSpawnedPosition = nightBorne.transform.position; 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MSSpawnStar()
	{
			Instantiate (Star, MSStarSpawnedPosition, Quaternion.identity);
			Debug.Log ("STar spawned");
	}
	void SKSpawnStar()
	{
			Instantiate (Star, SKStarSpawnedPosition, Quaternion.identity);
			Debug.Log ("STar spawned");
	}
	void GBSpawnStar()
	{
			Instantiate (Star, GBStarSpawnedPosition, Quaternion.identity);
			Debug.Log ("STar spawned");
	}
	void NBSpawnStar()
	{
			Instantiate (Star, NBStarSpawnedPosition, Quaternion.identity);
			Debug.Log ("STar spawned");
	}

	void SpawnAlter()
	{
		if (AlterSpawned == false)
		{
			AlterSpawned = true;
			Instantiate (Alter, AlterSpawnedPosition, Quaternion.identity);
			Debug.Log ("Alyter spawned");
		}
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		if(collision.gameObject.tag == "EndAlter")
			{
			SceneManager.LoadScene ("WinScreen");
			}
	}
		
}
