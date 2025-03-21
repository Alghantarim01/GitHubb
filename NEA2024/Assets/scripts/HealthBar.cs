using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
	
	public int Health;
	public Slider HeroHealthBar;
	private int Lives = 2;
	Animator HeroAnimator;
	GameObject Player;
	GameObject Mushroom;
	GameObject Skeleton;
	GameObject Goblin;
	GameObject NightBorne;
	GameObject BearTrap;
	GameObject Spike;
	// Use this for initialization
	void Start () // refrenaces all the game objects im going to use 
	{
		HeroAnimator = GetComponent<Animator> ();
		HeroHealthBar.value = 20;
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		Mushroom = GameObject.FindGameObjectWithTag ("MSAttackBox");
		Skeleton = GameObject.FindGameObjectWithTag ("SKAttackBox");
		Goblin = GameObject.FindGameObjectWithTag ("GBAttackBox");
		NightBorne = GameObject.FindGameObjectWithTag ("NBAttackBox");
		BearTrap = GameObject.FindGameObjectWithTag ("BearTrap");
		Spike = GameObject.FindGameObjectWithTag ("Spike");

	}

	// Update is called once per frame
	void Update ()
	{
		HeroHealthBar.value = Health; // ensures correct health bar value is displayed 
		if( Lives <= 0 )// if player runs out of lives display the lose screen 
		{
			SceneManager.LoadScene ("LoseScreen");
		}
	}

	void OnTriggerEnter2D (Collider2D collision)// depending on what the player touches it will either do a buff or debuff or remove health if touched a player
	{
		if (collision.gameObject.tag == "MSAttackBox")
		{
			Debug.Log ("hero got hit by ms");
			HeroAnimator.Play ("TakeHit");
			Health--;
		}
		if (collision.gameObject.tag == "SKAttackBox")
		{
			Debug.Log ("hero got hit sk");
			HeroAnimator.Play ("TakeHit");
			Health = Health-2;
		}
		if (collision.gameObject.tag == "GBAttackBox")
		{
			Debug.Log ("hero got hit gb");
			HeroAnimator.Play ("TakeHit");
			Health = Health - 3;
		}
		if (collision.gameObject.tag == "NBAttackBox")
		{
			Debug.Log ("hero got hit nb");
			HeroAnimator.Play ("TakeHit");
			Health = Health - 4;
		}
		if (collision.gameObject.tag == "BearTrap")
		{
			Debug.Log ("hero got hit bt");
			Health = Health - 20;
		}
		if (collision.gameObject.tag == "Spike")
		{
			Debug.Log ("hero got hit spk");
			Health = Health - 20;
		}
		if (collision.gameObject.tag == "HealthPot")
		{
			Debug.Log ("hero got health buff");
			Health = Health + 5;
		}
		if (collision.gameObject.tag == "HealthPoison")
		{
			Debug.Log ("hero got health debuff");
			Health = Health - 5;
		}
		if (collision.gameObject.tag == "NoDamagePot")
		{
			Debug.Log ("hero got health buff");
			Health = Health + 100;
			StartCoroutine (resetHealth());
		}
		if ( Health <=0)// if player health is zero play dead animation and start despawn coroutine
		{
			HeroAnimator.Play ("dead");
			StartCoroutine (Despawn ());
		}

	}
	IEnumerator Despawn ()// waits one second before it despawns the player and removes a live and starts the reset health coroutine 
	{
		yield return new WaitForSeconds (1f);
		Player.SendMessage ("resetPosition");
		StartCoroutine (resetHealth());
		Lives--;
	}
	IEnumerator resetHealth ()// waits a second to reset the health bar value and health 
	{
		yield return new WaitForSeconds (10f);
		HeroHealthBar.value = 20;
		Health = 20;
	}


}



