using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public Bullet bulletPrefab;
	private int direction = 2; // 1 is left, 2 is right

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// shootDirection ();
		shoot ();
	}

	/*
	void shootDirection() {
		if (Input.GetKey (KeyCode.A)) {
			this.direction = 1;
		}
		if (Input.GetKey (KeyCode.D)) {
			this.direction = 2;
		}
	}
	*/

	void shoot() {
		if (Input.GetKeyDown(KeyCode.G)) {
			// The direction the bullet is moving in
			int direction = 2; // 1 is left, 2 is right

			// Create the Bullet from the Bullet Prefab
			Bullet bullet = Instantiate(
				bulletPrefab,
				this.transform.position,
				this.transform.rotation);

			// bullet.updateDamage (playerDamage + bulletDamage);

			// Add velocity to the bullet
			if (this.direction == 1) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * -6;
			}
			if (this.direction == 2) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * 6;
			}
	
			// Destroy the bullet after 2 seconds
			Destroy(bullet.gameObject, 2.0f); 
		}

	}

}
