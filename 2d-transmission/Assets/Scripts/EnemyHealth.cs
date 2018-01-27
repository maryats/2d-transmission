using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth;

	private int curHealth;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// If this enemy collides with a bullet, deal damage to this enemy and remove the bullet
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.CompareTag ("Bullet")) {
//			TakeDamage (Bullet.dealDamage ()); TODO 
			collision.gameObject.SetActive (false);
		}
	}

	// Causes this unit to take damage. If the game crashes, make sure ints can't go negative
	void TakeDamage (int damage) {
		curHealth -= damage;

		// Kills this unit if the hp drops to or below 0
		if (curHealth <= 0) {
			gameObject.SetActive (false);
		}
	}
}
