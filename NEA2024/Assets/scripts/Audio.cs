using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {


	void Update () 
	{
		float sliderValue = PlayerPrefs.GetFloat ("Volume"); // ensures slider value is equal to the set volume 
		this.GetComponent<AudioSource> ().volume = sliderValue; // makes the volume of the music equal to the value of the slider 
	}
}
