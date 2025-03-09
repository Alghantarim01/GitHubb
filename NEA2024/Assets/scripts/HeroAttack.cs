using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour {

	Animator EnemyAnimator;
	GameObject Mushroom;
	GameObject Skeleton;
	GameObject NightBorne;
	GameObject Player;
	public Collider2D enemyCollider;
	public Collider2D playerCollider;




	// Use this for initialization
	void Start () {
		EnemyAnimator = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		Mushroom = GameObject.FindGameObjectWithTag ("Mushroom");
		Skeleton = GameObject.FindGameObjectWithTag ("Skeleton");
		NightBorne = GameObject.FindGameObjectWithTag ("NightBorne");



	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name == "Mushroom") 
		{
			
			//EnemyAnimator.Play ("MSTakeHit");
			Debug.Log ("reduce mushroom health");
			//Player.SendMessage ("MSTakeHitAnimation");
		}

	}
}
