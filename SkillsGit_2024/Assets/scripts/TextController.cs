using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {

	public TextMeshPro gemCounter;
	public TextMeshPro LivesCounter;
	public TextMeshPro GameTimer;
	int lives;

	GameObject [] totalGems;
	GameObject Hero;

	// Use this for initialization
	void Start ()
	{
		Hero = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		totalGems = GameObject.FindGameObjectsWithTag ("redGem");
		gemCounter.text = "Gems: " + totalGems.Length.ToString ();
		lives = Hero.GetComponent<HeroMovement>().Lives;
		LivesCounter.text = "Lives:" + lives;
		GameTimer.text = "Time" + Time.timeSinceLevelLoad.ToString("0.00");

		if (totalGems.Length == 0)
		{
			Hero.SendMessage ("SpawnAlter");
		}
	}
}
