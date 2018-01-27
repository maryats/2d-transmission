using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerHealth hunterHealth;
    public PlayerHealth gathererHealth;
    public Text loseMessage;

    private void Update()
    {
        if (hunterHealth.currentHealth <= 0
            || gathererHealth.currentHealth <= 0)
        {
            loseMessage.gameObject.SetActive(true);
        }
    }
}
