using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	GameObject Player;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D collision)
	{
		
		Player.SendMessage ("resetPosition");
	}
}
