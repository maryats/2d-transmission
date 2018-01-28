using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Shoot : MonoBehaviour {

	public Bullet bulletPrefab;
	private int direction = 2; // 1 is left, 2 is right

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// shootDirection ();
		shoot ();
	}

	/*
	void shootDirection() {
		if (Input.GetKey (KeyCode.A)) {
			this.direction = 1;
		}
		if (Input.GetKey (KeyCode.D)) {
			this.direction = 2;
		}
	}
	*/

	void shoot() {
		if (Input.GetKeyDown(KeyCode.G)) {
			// The direction the bullet is moving in
			int direction = 2; // 1 is left, 2 is right

			// Create the Bullet from the Bullet Prefab
			Bullet bullet = Instantiate(
				bulletPrefab,
				this.transform.position,
				this.transform.rotation);

			// bullet.updateDamage (playerDamage + bulletDamage);

			// Add velocity to the bullet
			if (this.direction == 1) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * -6;
			}
			if (this.direction == 2) {
				bullet.GetComponent<Rigidbody2D> ().velocity = bullet.transform.right * 6;
			}
	
			// Destroy the bullet after 2 seconds
			Destroy(bullet.gameObject, 2.0f); 
		}

	}

}
=======
public class Shoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Player player;
    private string playerTag;


    // Use this for initialization
    void Start()
    {
        playerTag = gameObject.tag;
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTag == "Hunter" && Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

        if (playerTag == "Gatherer" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            shoot();
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
>>>>>>> bb82ab115a87b831b6fbae00d3b92171ce02321b
