using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public GameObject ItemToSpawn;
	public int initialSpawnDelay = 0;
	public int spawnRate = 5;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnItem",initialSpawnDelay,spawnRate);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnItem() {
		Instantiate (ItemToSpawn);
	}

}
