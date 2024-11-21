using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Settings : MonoBehaviour {

	public Slider slider;
	public void volumeSlider ()
	{
		float audio = slider.value;
		PlayerPrefs.SetFloat ("Volume", audio);

	} 

	void Update(){
		slider.value = PlayerPrefs.GetFloat ("Volume");
	}
}
