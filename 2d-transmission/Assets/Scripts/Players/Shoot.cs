using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Player player;
    private string playerTag;
    public AudioClip ShootHunter;
    public AudioClip ShootGatherer;
    private AudioSource source1;
    private AudioSource source2;

    // Use this for initialization
    void Start()
    {
        playerTag = gameObject.tag;
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Player>();
        source1 = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTag == "Hunter" && Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
            source1.PlayOneShot(ShootHunter,0.7f);
        }

        if (playerTag == "Gatherer" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            shoot();
            source1.PlayOneShot(ShootGatherer,0.7f);
        }
    }

    void shoot()
    {
        // Create the Bullet from the Bullet Prefab
        Bullet bullet = Instantiate(
            bulletPrefab,
            player.transform.position,
            player.transform.rotation);

        //bullet.updateDamage (playerDamage + bulletDamage);

        // Add velocity to the bullet
        if (player.IsFacingRight())
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 6;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -6;
        }

        // Destroy the bullet after 2 seconds
        Destroy(bullet.gameObject, 2.0f);
    }
}