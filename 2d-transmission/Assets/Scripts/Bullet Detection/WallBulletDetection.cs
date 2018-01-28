using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBulletDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player Bullets" || collider.tag == "Boss Bullets")
        {
            Debug.Log("Bullet Hit");
            Destroy(collider.gameObject);
        }
    }
}
