using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject HealthUp;
	public GameObject AttackUp;
	public int spawnRate;

	private int timeTilNextSpawn;

	// Use this for initialization
	void Start () {
		// Spawn an initial one
		SpawnItem ();

		// Sets the time until the next spawn equal to the spawn rate
		timeTilNextSpawn = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		timeTilNextSpawn--;

		// Spawn a new item if there has been a delay equal to or greater than spawnRate
		if (timeTilNextSpawn <= 0) {
			timeTilNextSpawn = spawnRate;
			SpawnItem ();
		}
	}

	// Reset the timer if the item is still active
	void OnCollisionEnter(Collision collision) {
		if (collision.transform.CompareTag("HealthUp") || collision.transform.CompareTag("AttackUp")) {
			timeTilNextSpawn = spawnRate;
		}
	}

	// This actually spawns the item
	void SpawnItem() {
		// Create a random powerup
		GameObject ItemToSpawn;

		if (Random.Range(0, 2) == 1) {
			ItemToSpawn = HealthUp;
		}

		else {
			ItemToSpawn = AttackUp;
		}

		// Spawn that sucker
		Instantiate (ItemToSpawn, transform);
	}
}
