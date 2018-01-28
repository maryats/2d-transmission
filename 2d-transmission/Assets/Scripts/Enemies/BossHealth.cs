
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

    public int maxHealth = 200;
    public int currentHealth = 200;
	public Slider healthSlider;

	// Use this for initialization
	void Start () {
		healthSlider.value = currentHealth;   
	}
	
	// Update is called once per frame
	void Update () {
        amIDeadYet();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player Bullets")

        {
            int bulletDamage = col.gameObject.GetComponent<Bullet>().damage;
            this.currentHealth -= bulletDamage;
			healthSlider.value = currentHealth;   
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

