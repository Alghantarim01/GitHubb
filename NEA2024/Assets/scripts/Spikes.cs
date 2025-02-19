using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnCollisionEnter2d (Collision2D other)
	{
		Debug.Log ("colliosn detected with " + other.gameObject.name);

	}
}
