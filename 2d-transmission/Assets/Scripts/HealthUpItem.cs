using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour {

	//public int destroySeconds;
	public int recoverAmount;
    GameObject gatherer;
    public PlayerHealth gathererHealth;
    public float spawnTime;

    // Use this for initialization
    void Start () {
        gatherer = GameObject.Find("Gatherer");
        gathererHealth = gatherer.GetComponent<PlayerHealth>();
        //destroySeconds = 60;
        recoverAmount = 20;
       // Destroy (this.gameObject, destroySeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D gathererCollide)
    {
        GameObject colliding = gathererCollide.gameObject;
        if (colliding.tag == "Gatherer")
        {

            gathererHealth.Heal(recoverAmount);
            gameObject.SetActive(false);

            if (gameObject.activeSelf == false)
            {
                Debug.Log("Item Destroyed");
                Invoke("SpawnItem", spawnTime);
            }

        }
    }

    void SpawnItem()
    {
        Debug.Log("Item Spawned");
        gameObject.SetActive(true);
    }
}
