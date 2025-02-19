using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[UnityEngine.SerializeField] public Health playerHealth;
	[UnityEngine.SerializeField] public Image totalHealthBar;
	[UnityEngine.SerializeField] public Image currentHealthBar;
	// Use this for initialization
	private void Start () {
		totalHealthBar.fillAmount = playerHealth.currentHealth / 10 ;

	}
	
	// Update is called once per frame
	private void Update () {
		currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
	}
}
