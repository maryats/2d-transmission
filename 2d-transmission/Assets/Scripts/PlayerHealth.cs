using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int maxHealth = 100;
	public Slider healthSlider;


	// Use this for initialization
	void Start () {
		
	}

	public void Heal (int amount) {

		if ((currentHealth + amount) <= maxHealth) {
			currentHealth += amount;
		}
	}

	public void TakeDamage (int amount) {

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			Die ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Die () {
		playerMovement.enabled = false;
	}
}
