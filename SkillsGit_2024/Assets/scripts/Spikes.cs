using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	GameObject Hero;

	void Start () {
		Hero = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("SPIKED!");
		Hero.SendMessage ("restPosition");
	}

	void restPosition()
	{
		Debug.Log ("SPIKE RECEIVED!");
		transform.SetPositionAndRotation (new Vector3 (-5.58f, 1.34f, 0), Quaternion.identity);
	}
}
