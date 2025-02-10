using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

	Rigidbody2D rb;
	float speed;
	bool facingRight;
	private bool Jumped;
	public bool isGrounded;

	void Start () {
		speed = 5f;
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}
	void update()
	{
		if (Input.GetKey (KeyCode.Space) || (Input.GetKey (KeyCode.UpArrow)))
		{
			Jumped = true;
		}
	}
	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetKey (KeyCode.Space)))
		{
			rb.AddForce (Vector2.up * 350);
		}

     	float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);

		if (move > 0 && !facingRight) {
		flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}



		if(Jumped && isGrounded)
		{
			rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
			Jumped = false;
			isGrounded = true;
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}




	}


		
			
		













//if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.A))
//{
//transform.localScale = new Vector3 (2,2,1);
//facingRight = true;
//	}
//else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D))
//	{
//		transform.localScale = new Vector3 (-2,2,1);
//		facingRight = false;
//	}