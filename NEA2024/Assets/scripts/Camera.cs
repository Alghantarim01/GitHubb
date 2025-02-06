using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public GameObject HeroPlayer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (HeroPlayer.transform.position.x, HeroPlayer.transform.position.y + 2, -6.25f);
	}
}
