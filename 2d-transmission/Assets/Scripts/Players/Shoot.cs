/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	Player hunter = GameObject.FindGameObjectWithTag("Hunter").GetComponent<Player>();
	Player gatherer = GameObject.FindGameObjectWithTag("Gatherer").GetComponent<Player>();
	public Bullet bulletPrefab;
	//private int direction = 2; // 1 is left, 2 is right

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//shootDirection ();
		shoot ();
	}

	void shoot() {
		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			if (gatherer.direction == 2) {
				bulletPrefab = Instantiate (bulletPrefab, gatherer.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * bulletPrefab.speed);
			} else {
				bulletPrefab = Instantiate (bulletPrefab, gatherer.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * -bulletPrefab.speed);
			}
		}
		if(Input.GetKeyDown(KeyCode.Comma)) {
			if (hunter.direction == 2) {
				bulletPrefab = Instantiate (bulletPrefab, hunter.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * bulletPrefab.speed);
			} else {
				bulletPrefab = Instantiate (bulletPrefab, hunter.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * -bulletPrefab.speed);
			}
		}
	}


	void shootDirection() {
		if (Input.GetKey (KeyCode.A)) {
			this.direction = 1;
		}
		if (Input.GetKey (KeyCode.D)) {
			this.direction = 2;
		}
	}




	void shoot() {
		if (Input.GetKeyDown(KeyCode.G)) {
			// The direction the bullet is moving in
			int direction = 2; // 1 is left, 2 is right

			// Create the Bullet from the Bullet Prefab
			Bullet bullet = Instantiate(
				bulletPrefab,
				this.transform.position,
				this.transform.rotation);

			// bullet.aupdateDamage (playerDamage + bulletDamage);

			// Add velocity to the bullet
			if (this.direction == 1) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * -1 * bullet.speed;
			}
			if (this.direction == 2) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * bullet.speed;
			}

			// Destroy the bullet after 2 seconds

			Destroy(bullet.gameObject, 2.0f); 
		}

	}



} */
