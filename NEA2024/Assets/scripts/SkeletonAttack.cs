using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
	public Transform leftLimit ;
	public Transform rightLimit;
	private bool movingRight = false;
	public float moveSpeed = 2.5f;
	private bool isFacingRight = true;
	Animator EnemyAnimator;
	GameObject Player;
	GameObject HeroAttackBox;

	// Use this for initialization
	void Start () 
	{
		EnemyAnimator = GetComponent<Animator> ();// allows me to animate the enemy 
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		HeroAttackBox = GameObject.FindGameObjectWithTag ("HeroAttackBox");
	}

	// Update is called once per frame
	void Update ()
	{
		if (movingRight)// if the player is not moving right 
		{
			transform.position = Vector2.MoveTowards (transform.position, rightLimit.position, moveSpeed * Time.deltaTime);// move enemy towards the right maximum at a set speed 
			if (Vector2.Distance (transform.position, rightLimit.position) < 0.1f) // if the enemy has reached the right maximum flip the player and set moving right to false
			{
				movingRight = false;
				Flip ();
			}
		} 
		else 
		{
			transform.position = Vector2.MoveTowards (transform.position, leftLimit.position, moveSpeed * Time.deltaTime);// move enemy towards the left maximum at a set speed 
			if (Vector2.Distance (transform.position, leftLimit.position) < 0.1f) // if the enemy has reached the left maximum flip the player and set moving right to true
			{
				movingRight = true;
				Flip ();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collision)// if enemy touches player play attack animation 
	{
		if (collision.gameObject.name == "HeroPlayer")
		{
			EnemyAnimator.Play ("SKattack");
		} 
		if (collision.gameObject.name == "HeroAttackBox")// if enemy touches sword play take hit animation 
		{
			EnemyAnimator.Play ("SKhit");
		}
	}

		void Flip()// ensure the enemy if facing the right direction 
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}

}




