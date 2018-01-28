﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int maxHealth = 100;
	public Slider healthSlider;
	public PlayerHealth otherPlayerHealth;

	void Die () {
		print ("YOU DIED");
	}

	// Use this for initialization
	void Start () {
		// Player starts at full health
		currentHealth = maxHealth;

		// Update health slider to reflect Player stats
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;
	}

	public void Heal (int amount) {
		if ((currentHealth + amount) <= maxHealth) {
			currentHealth += amount;
		}
	}

	public bool IsDead () {
		return currentHealth <= 0;
	}

	public void SendHealth (int amount) {
		otherPlayerHealth.Heal (amount);
	}

	public void TakeDamage (int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			healthSlider.value = 0;
			Die ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}