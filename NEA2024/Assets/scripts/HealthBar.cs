using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[UnityEngine.SerializeField] private Health playerHealth;
	[UnityEngine.SerializeField] private Image totalHealthBar;
	[UnityEngine.SerializeField] private Image currentHealthBar;
	// Use this for initialization
	private void Start () {
		totalHealthBar.fillAmount = playerHealth.currentHealth / 10 ;

	}
	
	// Update is called once per frame
	private void Update () {
		currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
	}
}
