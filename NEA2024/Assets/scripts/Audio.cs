using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {


	void Update () {
		float sliderValue = PlayerPrefs.GetFloat ("Volume");
		this.GetComponent<AudioSource> ().volume = sliderValue;
	}
}
