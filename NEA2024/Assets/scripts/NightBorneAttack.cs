using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAttack : MonoBehaviour {

	Animator EnemyAnimator;
	GameObject Player;
	GameObject HeroAttackBox;

	// Use this for initialization
	void Start () 
	{
		EnemyAnimator = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		HeroAttackBox = GameObject.FindGameObjectWithTag ("HeroAttackBox");
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer")
		{
			EnemyAnimator.Play ("NBAttack");
			Debug.Log ("reduce player health");
		} 
		if (collision.gameObject.name == "HeroAttackBox") 
		{
			Debug.Log ("reduce enemy health");
			EnemyAnimator.Play ("NBTakeHit");
		}
	}
}
