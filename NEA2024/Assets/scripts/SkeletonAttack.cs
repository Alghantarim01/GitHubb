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
		EnemyAnimator = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("HeroPlayer");
		HeroAttackBox = GameObject.FindGameObjectWithTag ("HeroAttackBox");
	}

	// Update is called once per frame
	void Update ()
	{
		if (movingRight)
		{
			transform.position = Vector2.MoveTowards (transform.position, rightLimit.position, moveSpeed * Time.deltaTime);
			if (Vector2.Distance (transform.position, rightLimit.position) < 0.1f)
			{
				movingRight = false;
				Flip ();
			}
		} 
		else 
		{
			transform.position = Vector2.MoveTowards (transform.position, leftLimit.position, moveSpeed * Time.deltaTime);
			if (Vector2.Distance (transform.position, leftLimit.position) < 0.1f) 
			{
				movingRight = true;
				Flip ();
			}
		}
	}







	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name == "HeroPlayer")
		{
			EnemyAnimator.Play ("SKattack");
			Debug.Log ("reduce player health");
		} 
		if (collision.gameObject.name == "HeroAttackBox")
		{
			Debug.Log ("reduce enemy health");
			EnemyAnimator.Play ("SKhit");
		}
	}

		void Flip()
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}

			
}




