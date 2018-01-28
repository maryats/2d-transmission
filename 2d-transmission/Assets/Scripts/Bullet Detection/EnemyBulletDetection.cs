using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDetection : MonoBehaviour {

    /*// Health Stuff
    public Bullet bulletStats;
    private int bulletDamage;
    private int maxHealth;
    private int curHealth;

    // Spawn Stuff
    public float spawnTime = 3f;
    public float intSpawn = 1f;

    // Use this for initialization
    void Start()
    {
        // Health
        bulletDamage = bulletStats.damage;
        maxHealth = 15;
        curHealth = maxHealth;

        // Spawn
        Invoke("SpawnEnemy", intSpawn);
        InvokeRepeating("DeathCheck", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player Bullets")
        {
            Debug.Log("Bullet Hit");
            Destroy(collider.gameObject);
            TakeDamage(bulletDamage);
        }
    }

    // Causes this unit to take damage. If the game crashes, make sure ints can't go negative
    public void TakeDamage(int damage)
    {
        curHealth = curHealth - damage;

        // Kills this unit if the hp drops to or below 0
        if (curHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Spawn Methods

    void SpawnEnemy()
    {
        if (gameObject.activeSelf == true)
        {
            return;
        }
        else
        {
            gameObject.SetActive(true);
            curHealth = maxHealth;
        }

    }

    void DeathCheck()
    {
        if (gameObject.activeSelf == false)
        {
            Invoke("SpawnEnemy", spawnTime);
            Debug.Log("Spawning in 3");
        }
    }*/
}
