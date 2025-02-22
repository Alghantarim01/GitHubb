using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public int damage;
	public Health playerHealth;

	GameObject Player;


	void onCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == "HeroPlayer")
		{
			Debug.Log ("he colided");
			playerHealth.TakeDamage (damage);
		}
	}


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
