using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour {

	Animator MyAnimator; // allows me to animate my player 

	void Start ()
	{
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () // playes an animation depending on key strokes 
	{
		if (Input.GetKey (KeyCode.RightArrow) || (Input.GetKey (KeyCode.LeftArrow)|| (Input.GetKey (KeyCode.A)|| (Input.GetKey (KeyCode.D)))))
		{
			MyAnimator.SetBool ("walk", true);
		} 
		else 
		{
			MyAnimator.SetBool ("walk", false);
		}
		if (Input.GetKey (KeyCode.UpArrow) || (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.Space)))
		{
			MyAnimator.Play ("jump");
		} 
		else
		{
			MyAnimator.SetBool ("jump", false);
		}
		if (Input.GetKey (KeyCode.DownArrow) || (Input.GetKey (KeyCode.S)))
		{
			MyAnimator.SetBool ("dead", true);
		} 
		else
		{
			MyAnimator.SetBool ("dead", false);
		}
		if (Input.GetKey (KeyCode.Mouse0))
		{
			MyAnimator.SetBool ("attack", true);
		} 
		else
		{
			MyAnimator.SetBool ("attack", false);
		}
		if (Input.GetKey (KeyCode.Mouse1))
		{
			MyAnimator.SetBool ("attack2", true);
		} 
		else
		{
			MyAnimator.SetBool ("attack2", false);
		}
	}
}
