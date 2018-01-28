using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 100;
	public int currentHealth;
	public int maxHealth = 100;
	public Slider healthSlider;

	void Die () {
//		print ("YOU DIED"); // TODO delete?
	}

	// Use this for initialization
	void Start () {
		// Player starts at full health
		currentHealth = startHealth;

		// Update health slider to reflect Player stats
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;
	}

	public void Heal (int amount) {
		if ((currentHealth + amount) <= maxHealth) {
			currentHealth += amount;
			healthSlider.value = currentHealth;
		}
	}

	public bool IsDead () {
		return currentHealth <= 0;
	}

	public void SendHealth (PlayerHealth otherPlayerHealth, int amount) {
		otherPlayerHealth.Heal (amount);
		this.TakeDamage (amount);
	}

	public void TakeDamage (int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0) {
			healthSlider.value = 0;
			Die ();
			return;
		}
		healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
