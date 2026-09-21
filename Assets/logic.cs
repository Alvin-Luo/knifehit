using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logic : MonoBehaviour
{
    // scoreboard stuff
    private int score;
    public TMP_Text scoreText;

    // knife spawning stuff
    public GameObject spawner;

    // game over stuff
    public GameObject loseScreen;
    public Rotation rotate;

    // Start is called before the first frame update
    void Start()
    {
        rotate = GameObject.FindGameObjectWithTag("Target").GetComponent<Rotation>();
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        // stop spwaning knives
        spawner.SetActive(false);

        // activate lose screen
        loseScreen.SetActive(true);

        // stop rotating target
        rotate.rotationSpeed = 0;
    }

    public void addScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        // reload current scene to restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        // exit application
        Application.Quit();
    }
}
