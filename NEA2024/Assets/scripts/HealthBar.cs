using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {
	
	public int Health;
	public Slider HeroHealthBar;
	private int Respawns = 2;
	Animator HeroAnimator;
	GameObject Player;
	GameObject Mushroom;
	GameObject Skeleton;
	GameObject Goblin;
	GameObject NightBorne;
	GameObject BearTrap;
	GameObject Spike;
	// Use this for initialization
	void Start () 
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
		HeroHealthBar.value = Health;
		if( Respawns <= 0 )
		{
			SceneManager.LoadScene ("LoseScreen");
		}

	}
	void OnTriggerEnter2D (Collider2D collision)
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
		StartCoroutine (resetHealth());
		Respawns--;
		Debug.Log ("despawn player");
	}
	IEnumerator resetHealth ()
	{
		yield return new WaitForSeconds (10f);
		HeroHealthBar.value = 20;
		Health = 20;
		Debug.Log ("reset lives ");

	}


}



