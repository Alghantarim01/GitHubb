using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	
	[UnityEngine.SerializeField] private float startingHealth;
	public float currentHealth{ get; private set;}

	private void awake ()
	{
		currentHealth = startingHealth;
	}
	public void TakeDamage(float _damage)
	{
		currentHealth = Mathf.Clamp (currentHealth - _damage, 0, startingHealth);
		if (currentHealth > 0) {
			//playerhurt
		} else {
		}
	}

	private void update()
	{
		if(Input.GetKeyDown(KeyCode.E))
			TakeDamage(1);
			}
}

