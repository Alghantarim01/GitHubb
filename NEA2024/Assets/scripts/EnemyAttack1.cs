using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour {

	Animator EnemyAnimator;
	GameObject Player;



	// Use this for initialization
	void Start () {
		EnemyAnimator = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer")
		{
			EnemyAnimator.Play ("MSAttack");
			Debug.Log ("reduce player health");
		}
	}
	
}
