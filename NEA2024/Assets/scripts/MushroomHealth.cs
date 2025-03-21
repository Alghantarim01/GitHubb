using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomHealth : MonoBehaviour {

	public int Health;
	public Slider EnemyHealthBar;
	Animator EnemyAnimator;
	public GameObject HeroPlayer;

	// Use this for initialization
	void Start ()
	{
		EnemyAnimator = GetComponent<Animator> ();// allows me to animate the enemy 
		EnemyHealthBar.value = 4;// sets the health bar value of the enemy 

	}
	// Update is called once per frame
	void Update () 
	{
		EnemyHealthBar.value = Health;// ensures the right value health bar value is dispalyed 
	}

	void OnTriggerEnter2D (Collider2D collision)// if enemy touches player sword minus health 
	{
		if (collision.gameObject.name == "HeroAttackBox")
		{
			Health--;
		}
		if ( Health <=0)// if health is zero play death animation and start the despawn coroutine 
		{
			EnemyAnimator.Play ("MSDead");
			StartCoroutine (Despawn ());
		}
	}

	IEnumerator Despawn ()// wait a second before despawning the player and spawing the star 
	{
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
		HeroPlayer.SendMessage ("MSSpawnStar");

	}
		
}
