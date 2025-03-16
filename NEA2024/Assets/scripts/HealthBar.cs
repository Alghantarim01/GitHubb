using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	
	public int Health;
	public Slider EnemyHealthBar;
	Animator HeroAnimator;
	GameObject Player;
	// Use this for initialization
	void Start () 
	{
		HeroAnimator = GetComponent<Animator> ();
		EnemyHealthBar.value = 4;
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");

	}

	// Update is called once per frame
	void Update () 
	{
		EnemyHealthBar.value = Health;
	}
	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.tag == "EnemyAttackBox")
		{
			Debug.Log ("hero got hit");
			HeroAnimator.Play ("TakeHit");
			Health--;
		}
		if ( Health <=0)
		{
			HeroAnimator.Play ("dead");
			StartCoroutine (Despawn ());
		}
	}
	IEnumerator Despawn ()
	{
		yield return new WaitForSeconds (1f);
		Player.SendMessage ("resetPosition");
	}


}



