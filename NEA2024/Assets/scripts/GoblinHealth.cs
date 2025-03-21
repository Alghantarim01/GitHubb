using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealth : MonoBehaviour {

	public int Health; // health value
	public Slider EnemyHealthBar; // UI slider to represt how full the health bar is 
	Animator EnemyAnimator; // allows me to animate the enemy 
	public GameObject HeroPlayer; // refrence the player 

	// Use this for initialization
	void Start ()
	{
		EnemyAnimator = GetComponent<Animator> (); // allows me to animate enemy
		EnemyHealthBar.value = 10;// set the value of the health bar

	}
	// Update is called once per frame
	void Update () 
	{
		EnemyHealthBar.value = Health; // ensures the correct health is always displayed 
	}

	void OnTriggerEnter2D (Collider2D collision)// if the enemy touches the player sword minus 1 health point and if the health of enemy is zero play death animation
	{
		if (collision.gameObject.name == "HeroAttackBox")
		{
			Health--;
		}
		if ( Health <=0)
		{
			EnemyAnimator.Play ("GBDeath");
			StartCoroutine (Despawn ());
		}
	}

	IEnumerator Despawn ()// waits 1 second before it despawns the enemy then starts the star spawner method 
	{
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
		HeroPlayer.SendMessage ("GBSpawnStar");
	}
}
