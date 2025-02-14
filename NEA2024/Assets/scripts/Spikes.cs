using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	GameObject HeroPlayer;


	// Use this for initialization
	void Start () 
	{
		HeroPlayer = GameObject.FindGameObjectWithTag ("HeroPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnCollisionEnter2D (Collision2D other)
	{
		HeroPlayer.SendMessage("resetPosition");
	}
		
}
