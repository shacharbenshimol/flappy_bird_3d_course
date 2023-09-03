using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The MainMenuScripts class handles the main menu functionality, including navigation and panel display.
public class MainMenuScripts : MonoBehaviour
{
    // Public variable for the credits panel GameObject.
    public GameObject creditsPanel;

    // Start is called before the first frame update.
    private void Start()
    {
        // Initialize the credits panel as inactive.
        creditsPanel.SetActive(false);
    }

    // Method to handle the Play Game button click event.
    public void PlayGame()
    {
        // Load the scene named "flappyBird" to start the game.
        SceneManager.LoadScene("flappyBird");
    }

    // Method to handle the Credits button click event.
    public void Credits()
    {
        // Activate the credits panel to show the credits.
        creditsPanel.SetActive(true);
    }

    // Method to handle the Back button click event in the credits panel.
    public void Back()
    {
        // Deactivate the credits panel to return to the main menu.
        creditsPanel.SetActive(false);
    }
}
