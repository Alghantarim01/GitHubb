using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
	public Transform player; // player's  position 
	public float detectionRange = 10f; // Distance where enemy detects the player
	public float moveSpeed = 3f; // Speed of enemy 
	public float stopDistance = 0.5f; // Distance where enemy stops following the player
	public Transform leftLimit ; // maximum position the enemy goes to the left
	public Transform rightLimit; // maximum position the enemy goes to the right
	private bool isFacingRight = true; // direction the player is facing 
	public bool isChasingPlayer = false; // check if the enemy is following the player
	private bool movingRight = false; // diretion of travel 
	Animator EnemyAnimator;

	void start()
	{
		EnemyAnimator = GetComponent<Animator> (); // allows animate my enemy 
	}


	void Update()
	{
		float distanceToPlayer = Vector2.Distance(transform.position, player.position); // finds the playes postion and sets it to the varibale 

		if (distanceToPlayer < detectionRange && distanceToPlayer > stopDistance) // checks u=if the distance to the player is less than detection range and more than stop follow distance 
		{
			isChasingPlayer = true; // sets varibale to true 
			FollowPlayer (); // starts the method to follow the player 
		} 
		else
		{
			isChasingPlayer = false; // sets variable to false
			Patrol (); // starts the method to patrol 
		}
	}

	void Patrol()
	{
		if (movingRight) // check if enemy is moving right 
		{
			transform.position = Vector2.MoveTowards(transform.position, rightLimit.position, moveSpeed * Time.deltaTime); // makes the enemy move towards the right maximum at a set speed
			if (Vector2.Distance (transform.position, rightLimit.position) < 0.1f) // checks if enemy has reached the right limit 
			{
				movingRight = false; // sets the variable to false 
				Flip (); // flips the direction the enemy is facing 
			}
		}
		else
		{
			transform.position = Vector2.MoveTowards (transform.position, leftLimit.position, moveSpeed * Time.deltaTime); // makes the enemy move towards the left maximum at a set speed
			if (Vector2.Distance (transform.position, leftLimit.position) < 0.1f) // checks if enemy has reached the left limit 
			{
				movingRight = true; // sets the variable to true
				Flip (); // flips the direction the enemy is facing 
			}
		}
	}
		

	void FollowPlayer()
	{
		Vector2 targetPosition = new Vector2(player.position.x, transform.position.y); // gets the postion of the player 
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // makes the enemy move towards the players position at a set speed
		if ((player.position.x < transform.position.x && !isFacingRight) || (player.position.x > transform.position.x && isFacingRight)) // checks if the enemy is facing the player whilst they are in range 
		{
			Flip();// flips the direction the enemy is facing 
		}
	}

	void Flip() // makes the x axis scale minus making the sprit face the opposite direction 
	{
		isFacingRight = !isFacingRight; 
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
