using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public int maxHealth = 200;
    public int currentHealth = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        amIDeadYet();
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player Bullet")
        {
            int bulletDamage = col.gameObject.GetComponent<Bullet>().damage;
            this.currentHealth -= bulletDamage;
            Destroy(col.gameObject);
        }
    }

    void amIDeadYet()
    {
        if (this.currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
