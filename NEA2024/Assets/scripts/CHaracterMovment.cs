using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHaracterMovment : MonoBehaviour {

	Rigidbody2D rb;
	float speed;


	void Start () {
		speed = 5f;
		rb = GetComponent<Rigidbody2D> ();
		
	}
	

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow))
		{
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			rb.AddForce (Vector2.up * 350);
		}


	}
}
