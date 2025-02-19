using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
	public float jumpForce = 300.0f;
	private Rigidbody2D rb;
	private float speed = 5f;
	private	bool facingRight;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public bool grounded = false;
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
		bool jump = Input.GetButtonDown ("Jump") || Input.GetKeyDown(KeyCode.UpArrow);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, WhatIsGround);

		if (jump && grounded) GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpForce);
	
		

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}



		float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);

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
		Debug.Log ("spike recieved");
		transform.SetPositionAndRotation( new Vector3 (-10.5f, -2.7f, 0) , Quaternion.identity);
	}

	public void setLives()
	{
		if (lives <= 0)
		{
			Debug.Log ("end of game");
		}
	}
}

	