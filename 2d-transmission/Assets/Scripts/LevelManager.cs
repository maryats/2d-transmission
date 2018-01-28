using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject controlsScreen;
    [SerializeField]
    GameObject backButton;

    public void LoadLevel(string name)
    {
        //Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void ShowControls()
    {
        controlsScreen.SetActive(true);
        backButton.SetActive(true);
    }

    public void HideControls()
    {
        controlsScreen.SetActive(false);
        backButton.SetActive(false);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}
