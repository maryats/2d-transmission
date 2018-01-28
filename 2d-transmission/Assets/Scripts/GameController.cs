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

    private void Start()
    {
        hunter = GameObject.FindGameObjectWithTag("Hunter").GetComponent<Player>();
        gatherer = GameObject.FindGameObjectWithTag("Gatherer").GetComponent<Player>();
    }

    private void Update()
    {
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
