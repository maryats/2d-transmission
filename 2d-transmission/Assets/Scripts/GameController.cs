using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerHealth hunterHealth;
    public PlayerHealth gathererHealth;
    public Player hunter;
    public Player gatherer;
    public Text loseMessage;
	public Bullet bulletPrefab;
	int hunterDirection = 2; //1 is left  2 is right 
	int gathererDirection = 2; //1 is left 2 is right

    private void Start()
    {
        hunter = GameObject.FindGameObjectWithTag("Hunter").GetComponent<Player>();
        gatherer = GameObject.FindGameObjectWithTag("Gatherer").GetComponent<Player>();
    }

    private void Update()
    {
		if (Input.GetKeyDown (KeyCode.D)) {
			this.gatherer.direction = 2;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			this.gatherer.direction = 1;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.hunter.direction = 2;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.hunter.direction = 1;
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			if (gatherer.direction == 2) {
				bulletPrefab = Instantiate (bulletPrefab, gatherer.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * bulletPrefab.speed);
			} else {
				bulletPrefab = Instantiate (bulletPrefab, gatherer.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * -bulletPrefab.speed);
			}
		}
		if(Input.GetKeyDown(KeyCode.Comma)) {
			if (hunter.direction == 2) {
				bulletPrefab = Instantiate (bulletPrefab, hunter.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * bulletPrefab.speed);
			} else {
				bulletPrefab = Instantiate (bulletPrefab, hunter.transform.position, transform.rotation) as Bullet;
				bulletPrefab.transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
				bulletPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * -bulletPrefab.speed);
			}
		}
        //if (hunterHealth.currentHealth <= 0
        //    || gathererHealth.currentHealth <= 0)
        //{
        //    loseMessage.gameObject.SetActive(true);
        //}
    }

    private void FixedUpdate()
    {
        float horizontalGatherer = Input.GetAxis("HorizontalGatherer");
        float horizontalHunter = Input.GetAxis("HorizontalHunter");


        hunter.HandleMovement(horizontalHunter);
        hunter.Flip(horizontalHunter);

        gatherer.HandleMovement(horizontalGatherer);
        gatherer.Flip(horizontalGatherer);

        if (Input.GetKeyDown(KeyCode.W))
        {
            bool isgrounded = gatherer.IsGrounded();
            if (isgrounded)
                gatherer.HandleJump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bool isgrounded = hunter.IsGrounded();
            if (isgrounded)
                hunter.HandleJump();
        }
    }
		
}
