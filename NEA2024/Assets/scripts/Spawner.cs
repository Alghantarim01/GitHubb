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
		MSStarSpawnedPosition = mushroom.transform.position;  // gets position of enemy 
		SKStarSpawnedPosition = skeleton.transform.position; // gets position of enemy  
		GBStarSpawnedPosition = goblin.transform.position;  // gets position of enemy 
		NBStarSpawnedPosition = nightBorne.transform.position;  // gets position of enemy 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MSSpawnStar()// spawns the star at the postion of the enemy 
	{
			Instantiate (Star, MSStarSpawnedPosition, Quaternion.identity);
	}
	void SKSpawnStar()// spawns the star at the postion of the enemy 
	{
			Instantiate (Star, SKStarSpawnedPosition, Quaternion.identity);
	}
	void GBSpawnStar()// spawns the star at the postion of the enemy 
	{
			Instantiate (Star, GBStarSpawnedPosition, Quaternion.identity);
	}
	void NBSpawnStar()// spawns the star at the postion of the enemy 
	{
			Instantiate (Star, NBStarSpawnedPosition, Quaternion.identity);
	}

	void SpawnAlter()// spawns alter 
	{
		if (AlterSpawned == false)
		{
			AlterSpawned = true;
			Instantiate (Alter, AlterSpawnedPosition, Quaternion.identity);
		}
	}

	void OnTriggerEnter2D (Collider2D collision)// if player touches the alter load the win screen 
	{
		if(collision.gameObject.tag == "EndAlter")
			{
			SceneManager.LoadScene ("WinScreen");
			}
	}
		
}
