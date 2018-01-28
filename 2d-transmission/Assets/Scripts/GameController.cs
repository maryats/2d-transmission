using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public PlayerHealth hunterHealth;
    //public PlayerHealth gathererHealth;
    private Player hunter;
    private Player gatherer;

    bool gameEnded;

    [SerializeField]
    GameObject promptLose;

    [SerializeField]
    GameObject promptWin;

    private void Start()
    {
        hunter = GameObject.FindGameObjectWithTag("Hunter").GetComponent<Player>();
        gatherer = GameObject.FindGameObjectWithTag("Gatherer").GetComponent<Player>();
    }

    private void Update()
    {
        // Lose?
        if (hunter.playerHealth.currentHealth <= 0
            || gatherer.playerHealth.currentHealth <= 0)
        {
            promptLose.SetActive(true);
            gameEnded = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gatherer.jump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hunter.jump = true;
        }
        if(Input.GetKey(KeyCode.S))
        {
            gatherer.playerHealth.SendHealth(hunter.playerHealth, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            hunter.playerHealth.SendHealth(gatherer.playerHealth, 1);
        }

        // Go back to main menu
        if(gameEnded && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void FixedUpdate()
    {
        float horizontalGatherer = Input.GetAxis("HorizontalGatherer");
        float horizontalHunter = Input.GetAxis("HorizontalHunter");


        hunter.HandleMovement(horizontalHunter);
        hunter.Flip(horizontalHunter);

        gatherer.HandleMovement(horizontalGatherer);
        gatherer.Flip(horizontalGatherer);

        //bool isgrounded = gatherer.IsGrounded();
        //if (Input.GetKeyDown(KeyCode.W) && isgrounded)
        //{
        //    gatherer.HandleJump();
        //}

        //isgrounded = hunter.IsGrounded();
        //if (Input.GetKeyDown(KeyCode.UpArrow) && isgrounded)
        //{
        //    hunter.HandleJump();
        //}
    }
}
