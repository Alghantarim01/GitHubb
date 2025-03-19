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
		EnemyAnimator = GetComponent<Animator> ();
		EnemyHealthBar.value = 4;

	}
	// Update is called once per frame
	void Update () 
	{
		EnemyHealthBar.value = Health;
	}

	void makeDead()
	{
		Destroy (gameObject);
	}
		
	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name == "HeroAttackBox")
		{
			Health--;
		}
		if ( Health <=0)
		{
			EnemyAnimator.Play ("MSDead");
			StartCoroutine (Despawn ());
		}
	}

	IEnumerator Despawn ()
	{
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
		HeroPlayer.SendMessage ("MSSpawnStar");

	}
		
}
