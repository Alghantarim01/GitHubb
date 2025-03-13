using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
	public Transform player; // Reference to the player's Transform
	public float detectionRange = 10f; // Distance at which enemy detects the player
	public float moveSpeed = 3f; // Speed at which enemy moves
	public float stopDistance = 0.5f; // Distance at which enemy stops moving toward the player
	public Transform leftLimit ;
	public Transform rightLimit;
	private bool isFacingRight = true;
	private bool isChasingPlayer = false;
	private bool movingRight = false;
	Animator EnemyAnimator;


	void Update()
	{

		float distanceToPlayer = Vector2.Distance(transform.position, player.position);

		if (distanceToPlayer < detectionRange && distanceToPlayer > stopDistance) 
		{
			isChasingPlayer = true;
			FollowPlayer ();
		} 
		else
		{
			isChasingPlayer = false;
			Patrol ();
		}
	}

	void Patrol()
	{
		if (movingRight )
		{
			transform.position = Vector2.MoveTowards(transform.position, rightLimit.position, moveSpeed * Time.deltaTime);
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
		

	void FollowPlayer()
	{
		Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

		// Flip enemy if moving in the opposite direction
		if ((player.position.x < transform.position.x && !isFacingRight) || (player.position.x > transform.position.x && isFacingRight))
		{
			Flip();
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
