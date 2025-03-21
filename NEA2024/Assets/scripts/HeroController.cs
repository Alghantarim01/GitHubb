using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	public float jumpForce = 300.0f;
	private Rigidbody2D rb;
	private float speed = 7f;
	private	bool facingRight;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public bool grounded = false;
	private int jumpCount = 0;
	private float maxJump = 1;
	private bool DoubleJumpOn = false;
	public LayerMask WhatIsGround;
	public int lives = 2;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> (); 
		facingRight = true; // sets variable to true 
	}
		
	void update()
	{

	}

	void FixedUpdate ()
	{
		bool jump = Input.GetButtonDown ("Jump");
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround); // checks if the player is touching the ground 

		if (Input.GetButtonDown ("Jump") && grounded && DoubleJumpOn == false) // allows the player to jump if they dont have a buff and they are touching the ground
		{
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
		}

		if (grounded) // if player is touching the gorund reset the jump count
		{
			jumpCount = 0;
		}
			// Jump Logic
		if (Input.GetButtonDown ("Jump") && DoubleJumpOn == true && jumpCount < maxJump) // if buff enabled the player can double jump and inrement jump count
		{ 
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
			jumpCount++;
		}

		float move = Input.GetAxis ("Horizontal"); // allows the player to move 
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);
		//Debug.Log ("current speed" + speed);

		if (move > 0 && !facingRight) // ensures the player faces the right direction 
		{
			flip ();
		} 
		else if (move < 0 && facingRight) 
		{
			flip ();
		}
	}

	void flip()// ensures the player is facing the right way by multipling the x axis scale by -1 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D collision)// applies buff or debuff depending on what the player collides with 
	{
		if (collision.gameObject.tag == "SpeedPot")
		{
			speed = 10f;
			StartCoroutine (ResetSpeed());
		}
		if (collision.gameObject.tag == "SpeedPoison")
		{
			speed = 4f;
			StartCoroutine (ResetSpeed());
		}
		if (collision.gameObject.tag == "DoubleJumpPot")
		{
			DoubleJumpOn = true;
			StartCoroutine (ResetDoubleJump());
		}
		if (collision.gameObject.tag == "JumpPoison")
		{
			jumpForce = 200f;
			StartCoroutine (ResetJump());
		}
		if (collision.gameObject.tag == "WeakPoison")
		{
			speed = 0f;
			StartCoroutine (ResetSpeed());
		}
	}

	IEnumerator ResetSpeed()// resets the speed of player after 10 seconds 
	{
		yield return new WaitForSeconds(10f);
		speed = 7f;
	}
		
	IEnumerator ResetJump() // resets the jump highet of player after 5 seconds 
	{
		yield return new WaitForSeconds(5f);
		jumpForce = 300f;
	}
	IEnumerator ResetDoubleJump() 
	{
		yield return new WaitForSeconds(10f); // resets the double jump buff
		DoubleJumpOn = false;
	}
}

	