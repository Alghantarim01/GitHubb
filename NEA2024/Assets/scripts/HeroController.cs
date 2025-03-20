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
		facingRight = true;
	}


	void update()
	{

	}

	void FixedUpdate ()
	{
		bool jump = Input.GetButtonDown ("Jump");
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround);

		if (Input.GetButtonDown ("Jump") && grounded && DoubleJumpOn == false)
		{
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
		}

		if (grounded) 
		{
			jumpCount = 0;
		}
			// Jump Logic
		if (Input.GetButtonDown ("Jump") && DoubleJumpOn == true && jumpCount < maxJump)
		{ 
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
			jumpCount++;
		}
		
	



		float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);
		//Debug.Log ("current speed" + speed);

		if (move > 0 && !facingRight) 
		{
			flip ();
		} 
		else if (move < 0 && facingRight) 
		{
			flip ();
		}
	}





	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void resetPosition()
	{
		transform.SetPositionAndRotation( new Vector3 (-10.5f, -2.7f, 0) , Quaternion.identity);
	}
		

	void OnTriggerEnter2D (Collider2D collision)
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

	IEnumerator ResetSpeed()
	{
		yield return new WaitForSeconds(10f);
		speed = 7f;
	}
		
	IEnumerator ResetJump()
	{
		yield return new WaitForSeconds(5f);
		jumpForce = 300f;
	}
	IEnumerator ResetDoubleJump()
	{
		yield return new WaitForSeconds(15f);
		DoubleJumpOn = false;
	}




}

	