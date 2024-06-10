using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimations : MonoBehaviour {

	Animator MyAnimator;
	void Start () {
		MyAnimator = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.RightArrow))
		{
			MyAnimator.SetBool ("walk", true);
		} 
		else 
		{
			MyAnimator.SetBool ("walk", false);
		}
	}
}