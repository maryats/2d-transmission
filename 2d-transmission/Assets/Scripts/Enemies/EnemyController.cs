using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Controller Stuff
    public float movementSpeed = .01f;

    public bool runForwards = true;

    private SpriteRenderer mySpriteRenderer;

    // Health Stuff
    public Bullet bulletStats;
    private int bulletDamage;
    private int maxHealth;
    private int curHealth;

    // Spawn Stuff
    public float spawnTime = 3f;
    public float intSpawn = 1f;

    private void Start()
    {
        // Controller
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        gameObject.SetActive(false);

        // Health
        bulletDamage = bulletStats.damage;
        maxHealth = 15;
        curHealth = maxHealth;

        // Spawn
        Invoke("SpawnEnemy", intSpawn);
        InvokeRepeating("DeathCheck", spawnTime, spawnTime);
    }

    void Update()
    {
        UpdatePosition();

        if (runForwards)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    void UpdatePosition()
    {

        Vector2 oPos = transform.position;
        float calculatedPosition;

        if (runForwards)
        {
            transform.position = new Vector2(oPos.x + movementSpeed, oPos.y);
        }
        else
        {
            transform.position = new Vector2(oPos.x - movementSpeed, oPos.y);
        }

        
    }

    void CollisionHandler(Collider2D collider)
    {
        if (collider.tag == "Right Edge")
        {
            runForwards = false;
            //Debug.Log("Triggered");

            // Or
            // JumpBackwards()
        }
        else if (collider.tag == "Left Edge")
        {
            runForwards = true;


            // Or
            // JumpForwards()
        }
        else if (collider.tag == "Player Bullets")
        {
            Debug.Log("Bullet Hit");
            Destroy(collider.gameObject);
            TakeDamage(bulletDamage);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        CollisionHandler(collider);
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
    }
}
