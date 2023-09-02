using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    private void Start()
    {
        creditsPanel.SetActive(false);
    }

    public GameObject creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("flappyBird");
    }
    
    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void Back()
    {
        creditsPanel.SetActive(false);
    }


}
