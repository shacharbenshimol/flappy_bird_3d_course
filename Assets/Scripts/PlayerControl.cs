using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float Force;
    private Rigidbody2D rb;

    private int Points = 0;

    private int HighScore = 0;
    public Text ScoreText;
    
    public Text HighScoreText;
    public Text ScoreOnPannel;

    public GameObject diePannel;
    void Start()
    {
        diePannel.SetActive(false);
        HighScore = PlayerPrefs.GetInt("HighScore");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           rb.velocity = Vector2.up * Force;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
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

        diePannel.SetActive(true);
        ScoreOnPannel.text = Points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PipeScore")
        {
            Points++;
            ScoreText.text = Points.ToString();

            
        }
    }

    public void ok()
    {
        diePannel.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}
