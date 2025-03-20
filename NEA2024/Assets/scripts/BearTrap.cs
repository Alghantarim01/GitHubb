using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour {

	GameObject Player; 
	Animator MyAnimator;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer"); // finds the player 
		MyAnimator = GetComponent<Animator> (); // allows me to animate the bear trap 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer") // sees if the player collided with bear trap 
		{
			MyAnimator.SetTrigger ("attack"); // plays the attack animation 
		}
	}
}
