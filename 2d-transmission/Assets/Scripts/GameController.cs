using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text loseMessage;

    private void Update()
    {
        if (playerHealth.currentHealth < 0)
        {
            loseMessage.gameObject.SetActive(true);
        }
    }
}
