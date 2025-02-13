using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	
	public float fullHealth;
	float currentHealth;
	HeroController controlMovement;

	// Use this for initialization
	void Start () 
	{
		currentHealth = fullHealth;

		controlMovement = GetComponent<HeroController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void addDamage(float damage)
	{
		if (damage <= 0)
			return;
		currentHealth -= damage;
		if (currentHealth <= 0) {
			makeDead ();
		}

	}

	public void makeDead ()
	{
		Destroy (gameObject);
	}
}

