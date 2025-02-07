using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour {


	private bool flipped;


	Animator MyAnimator;

	void Start ()
	{
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			MyAnimator.SetBool ("walk", true);
		} 
		else 
		{
			MyAnimator.SetBool ("walk", false);
		}

		if (Input.GetKey (KeyCode.UpArrow))
		{
			MyAnimator.Play ("jump");
		} 
		else
		{
			MyAnimator.SetBool ("jump", false);
		}

		if (Input.GetKey (KeyCode.LeftShift))
		{
			MyAnimator.SetBool ("run", true);
		} 
		else 
		{
			MyAnimator.SetBool ("run", false);
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			MyAnimator.SetBool ("dead", true);
		} 
		else
		{
			MyAnimator.SetBool ("dead", false);
		}









	}
}
