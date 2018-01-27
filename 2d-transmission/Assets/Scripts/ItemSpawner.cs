using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject ItemToSpawn;
	public int spawnRate;

	private Vector2 location;
	private int timeTilNextSpawn;

	// Use this for initialization
	void Start () {
		// Spawn an initial one
		SpawnItem ();

		// Get the location of this object instead of the duplicated object
		float x = transform.position.x;
		float y = transform.position.y;
		location = new Vector2 (x, y);

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
		if (collision.transform.CompareTag(ItemToSpawn.transform.tag) {
			timeTilNextSpawn = spawnRate;
		}
	}

	// This actually spawns the item
	void SpawnItem() {
		Instantiate (ItemToSpawn, location);
	}

}
