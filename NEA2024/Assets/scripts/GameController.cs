using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {


	public TextMeshPro enemyCounter;
	public GameObject HeroPlayer;
	GameObject [] totalEnemies;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		enemyCounter.text = "enemies" + totalEnemies.Length.ToString ();
		if (totalEnemies.Length == 0) {
			HeroPlayer.SendMessage ("SpawnAlter");
		}
	}
}
