using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour {

	//public int destroySeconds;
	public int recoverAmount;
    GameObject gatherer;
    public PlayerHealth gathererHealth;
    private float spawnTime;

    // Use this for initialization
    void Start () {
        gatherer = GameObject.Find("Gatherer");
        gathererHealth = gatherer.GetComponent<PlayerHealth>();
        spawnTime = 7f;
        recoverAmount = 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D gathererCollide)
    {
        GameObject colliding = gathererCollide.gameObject;
        if (colliding.tag == "Gatherer")
        {

            gameObject.SetActive(false);
            gathererHealth.Heal(recoverAmount);
            Invoke("SpawnItem", spawnTime);

        }
    }

    void SpawnItem()
    {
        Debug.Log("Item Spawned");
        gameObject.SetActive(true);
    }
}
