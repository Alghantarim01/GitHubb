using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : MonoBehaviour {

	Animator EnemyAnimator;
	GameObject Player;
	GameObject HeroAttackBox;

	// Use this for initialization
	void Start () 
	{
		EnemyAnimator = GetComponent<Animator> (); // allows me to animate my enemy 
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer"); // find the player 
		HeroAttackBox = GameObject.FindGameObjectWithTag ("HeroAttackBox"); // find the player sword 
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer") // checks if the player has touched the enemy 
		{
			EnemyAnimator.Play ("GBAttack"); // plays enemy attack animation 
		} 
		if (collision.gameObject.name == "HeroAttackBox") // checks if the player sword has touched the enemy
		{
			EnemyAnimator.Play ("GBTakeHit"); // plays enemy hurt animation 
		}
	}
}
