using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// The PlayerControl class handles the player's movements, scoring, and game state.
public class PlayerControl : MonoBehaviour
{
    // Public variables to set player behavior and UI elements in Unity Editor.
    public float Force;
    public Text ScoreText;
    public Text HighScoreText;
    public Text ScoreOnPannel;

    // Private variables to manage internal state.
    private Rigidbody2D rb;
    private int Points = 0;
    private int HighScore = 0;

    // Start is called before the first frame update.
    public GameObject diePannel;
    public GameObject bird;

    void Start()
    {
        bird.SetActive(true);
        diePannel.SetActive(false);
        HighScore = PlayerPrefs.GetInt("HighScore");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         // Jump when the mouse button is clicked.
        if(Input.GetMouseButtonDown(0))
        {
           rb.velocity = Vector2.up * Force;
        }
    }

    // OnCollisionEnter2D is called when this collider/rigidbody begins touching another rigidbody/collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
         // Update high score if current points are greater.
        if(HighScore < Points)
        {
            HighScore = Points;
            HighScoreText.text = ScoreText.text;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
        else
        {
            HighScoreText.text = HighScore.ToString();
        }

        // Activate the death panel and display the final score.
        diePannel.SetActive(true);
        bird.SetActive(false);
        ScoreOnPannel.text = Points.ToString();
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increase the score when passing a pipe.
        if(collision.gameObject.tag == "PipeScore")
        {
            Points++;
            ScoreText.text = Points.ToString();

            
        }
    }

    // Method to handle the OK button on the death panel.
    public void ok()
    {
        diePannel.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }

    // OnDestroy is called when the game object is destroyed.
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}
