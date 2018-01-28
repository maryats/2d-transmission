using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 100;
	private int currentHealth;
	public int maxHealth = 100;
	public Slider healthSlider;
	public PlayerHealth otherPlayerHealth;

    [SerializeField]
    private AudioSource sourceDeath;
    [SerializeField]
    private AudioSource sourcehurt;
	[SerializeField]
	private AudioSource sourcetransfer;
    
	// Use this for initialization
	void Start ()
    {
		// Player starts at full health
		currentHealth = startHealth;

		// Update health slider to reflect Player stats
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;   
	}

	public void Heal (int amount)
    {
		if ((currentHealth + amount) <= maxHealth)
        {
			currentHealth += amount;
			healthSlider.value = currentHealth;
		}
        else if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
            healthSlider.value = currentHealth;
        }
	}

	public bool IsDead ()
    {
		return currentHealth <= 0;
	}

	public void SendHealth (PlayerHealth otherPlayerHealth, int amount) {
		sourcetransfer.Play();
		otherPlayerHealth.Heal (amount);
		this.TakeDamage (amount);
	}

	public void TakeDamage (int amount)
    {
		currentHealth -= amount;
        sourcehurt.Play();
		if (currentHealth <= 0)
        {
			healthSlider.value = 0;
			Die ();
			return;
		}
		healthSlider.value = currentHealth;
	}

    void Die()
    {
        sourceDeath.Play();
		gameObject.SetActive (false);
    }
   
    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown (KeyCode.Z))
			sourceDeath.Play();
    }

    private void OnCollisionEnter2D(Collision2D collidor)
    {
		if (collidor.gameObject.tag == "Mob") {
			TakeDamage(5);
		}

		if (collidor.gameObject.tag == "Boss") {
				TakeDamage(10);
		}
			
		if (collidor.gameObject.tag == "Boss Bullets") {
			TakeDamage(5);
		}
    }
}
