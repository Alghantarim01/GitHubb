using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter2D(Collider2D other)// despawns star once olayer collects it 
	{
		if (other.gameObject.tag == "HeroPlayer") 
		{
			Destroy (gameObject);
		}
	}

}
