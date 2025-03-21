using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour {

	public Slider CollectedStars;
	public int Stars;
	public GameObject HeroPlayer;


	// Use this for initialization
	void Start () 
	{
		CollectedStars.value = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CollectedStars.value = Stars; // ensures the right value is displayed for the stars 
		if ( Stars >= 3 )// if all stars are collected start the spawn alter method 
		{
			HeroPlayer.SendMessage ("SpawnAlter");
		}
	}

	void OnTriggerEnter2D (Collider2D collision)// if player touches a star increment the amount of stars 
	{
		if (collision.gameObject.tag == "Star")
		{
			Stars ++;
		}
	}

}
