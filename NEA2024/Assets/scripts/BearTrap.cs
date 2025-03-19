using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour {

	GameObject Player;
	Animator MyAnimator;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer")
		{
			MyAnimator.SetTrigger ("attack");
		}
	}
}
