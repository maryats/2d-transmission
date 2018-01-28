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
        if(Input.GetKeyDown(KeyCode.W))
        {
            gatherer.jump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hunter.jump = true;
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
